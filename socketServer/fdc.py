import socket
import threading
import json
# import pymysql
import time
import psycopg2
import datetime as dt
# import requests

fdc_port = 8888
mes_port = 8887
mutex = threading.Lock()

# Socket 으로 받은 Data를 1분간 할당할 Memory
storage = []
temp = []
# intervalSave 함수를 th2로 돌릴 단위 시간(초)
save_interval = 60
last_save_time = time.time()


def FDCServer():	
    global storage, last_save_time
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)	
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    server_socket.bind(('172.26.6.41', fdc_port))	
    server_socket.listen(1)	

    print("FDC server Socket listening...")

    while True:
        # mutex.acquire()
        with mutex:
            client_socket, addr = server_socket.accept()
        print('Join : ', addr)
        # mutex.release()

        try:
            # 접속 상태에서 메세지 수신 무한 대기, 접속 끊기면 except 발생
            while True:	
                
                # 1024 byte 데이터 수신 대기
                with mutex:
                    data = client_socket.recv(1024)	
                    # little 엔디언으로 byte에서 int로 변환
                    length = int.from_bytes(data, "little") 
                    # 다시 데이터 수신 대기
                    data = client_socket.recv(length)
                # 수신된 데이터 문자열 형태로 Decoding	
                msg = data.decode()	
                if (length > 0):
                    print(addr, ' 에서', msg,' 를 보냈습니다.')
                    # Data dict 형변환 
                    data = json.loads(data)
                    # print(data)
                    # print(storage)
                    # Interlock 감지 및 인터락 설비 데이터 바로 DB 저장 함수 호출
                    CheckInterlock(data)
                    storage.append(data)
                    
                    # print("interlock")
                    # Data Spec MES 기준정보와 비교하고 다른 경우 업데이트하는 함수 호출
                    CheckwithMES(data)
                        
                # Client 에게 메세지 송신 (echo), 수신과 서순 반대
                msg = "FDC 서버에서 수신 : " + msg	
                data = msg.encode()		
                length = len(data)	
                with mutex:
                    client_socket.sendall(length.to_bytes(1024, byteorder='little'))		
                    client_socket.sendall(data)
                # print("응답완료")

                # 단위 시간마다 2번 스레드 동작
                elapsed_time = time.time() - last_save_time
                if elapsed_time > save_interval:
                    # 2번 스레드는 intervalSave 함수
                    th2 = threading.Thread(target=intervalSave)
                    th2.start()
                    last_save_time = time.time() 
        except:	
            print("Exit : " , addr)	
        finally:		
            client_socket.close() 



# interlock 판정
def CheckInterlock(data):
    global temp
    conn = psycopg2.connect(host='k8a201.p.ssafy.io',
                            database='fdc',
                            user='cms',
                            password='1234')
    # print("connect success")
    cursor = conn.cursor()
    try:
        val = data["data_value"]
        recipe_id = data["recipe_id"]
        cause_equip_id = data['equipment_id']
        created_at = data["created_at"]
        # lot_id = data["lot_id"]
        param_id = data["param_id"]
        recipe_sql = f"SELECT * FROM recipe WHERE recipe_id = '{recipe_id}'"
        cursor.execute(recipe_sql)
        recipe = cursor.fetchone()
        # print(f'asd {recipe}')

        cursor.close()
        lsl = recipe[2]
        usl = recipe[3]
        # Interlock 판단, type 결정
        if val < lsl:
            interlock_type = recipe[4]    
        elif val > usl:
            interlock_type = recipe[5]
        else:
            interlock_type = 0
    except Exception as e:
        print(f'except {e}')

    # Interlock 무결 판정이면 DB 접속 종료
    if interlock_type == 0:
        print("--------------Safe Data--------------")
        data["is_interlock"] = False
        conn.close()
    else:
        data["is_interlock"] = True
        # TODO
        with mutex:
            temp.append(data)
            
        # Interlock 판정 데이터는 DB에 바로 저장
        print("--------------Interlock Found--------------")
        # print(data)
        upper_limit = usl
        data_value = val
        lower_limit = lsl
        cause_equip_id = cause_equip_id
        equip_sql = f"SELECT * FROM equipment WHERE equipment_id = '{cause_equip_id}'"
        cursor = conn.cursor()
        cursor.execute(equip_sql)
        equip = cursor.fetchone()
        cursor.close()
        equipment_id = equip[9]
        # print("1")
        
        cnt_sql = f"SELECT * FROM interlock_log WHERE equipment_id = '{equipment_id}' AND param_id = '{param_id}' AND recipe_id = '{recipe_id}'"
        cursor = conn.cursor()
        cursor.execute(cnt_sql)
        cnt = cursor.fetchall()
        out_count = len(cnt)
        cursor.close()
        # print("2")

        now = dt.datetime.now()
        file_name = now.strftime("%Y_%m_%d_%H_%M")
        url = f"https://firebasestorage.googleapis.com/v0/b/ssafy-a201.appspot.com/o/{equipment_id}%2F{file_name}.avi?alt=media"
        # print("3")

        try:
            # ...
            insert_sql = f"INSERT INTO interlock_log (created_at, interlock_type, upper_limit, data_value, lower_limit, cause_equip_id, equipment_id, param_id, recipe_id, out_count, cctv_video_url) VALUES ('{created_at}','{interlock_type}','{upper_limit}','{data_value}','{lower_limit}','{cause_equip_id}','{equipment_id}','{param_id}','{recipe_id}','{out_count}','{url}')"
            cursor = conn.cursor()
            cursor.execute(insert_sql)
            conn.commit()
            cursor.close()
            conn.close()
            print("--------------Input Interlock Data to DB--------------")
        except Exception as e:
            print(f'Insert error: {e}')



# def temp(data):
#         # API endpoint
#     url = "http://localhost:8000/param_log/"

#     # data to be sent to API
#     data = data

#     # sending post request
#     response = requests.post(url, data=json.dumps(data), headers={'Content-Type': 'application/json'})

#     # print response
#     print(response.json())
     

# 기준정보 업데이트
def CheckwithMES(data):
    try:
        conn = psycopg2.connect(host='k8a201.p.ssafy.io',
                            database='fdc',
                            user='cms',
                            password='1234')
        cursor = conn.cursor()

        equipment_id = data["equipment_id"]
        param_id = data["param_id"]
        recipe_id = data["recipe_id"]

        param_sql = f"SELECT * FROM param WHERE param_id = '{param_id}' AND equipment_id = '{equipment_id}'"
        cursor.execute(param_sql)
        param = cursor.fetchone()
        param_level = param[2]

        recipe_sql = f"SELECT * FROM recipe WHERE recipe_id = '{recipe_id}'"
        cursor.execute(recipe_sql)
        recipe = cursor.fetchone()
        lsl = recipe[2]
        usl = recipe[3]
        lsl_interlock_action = recipe[4]
        usl_interlock_action = recipe[5]
        
        # TODO 1 MES DB 채워넣어야함
        connMES = psycopg2.connect(host='k8a201.p.ssafy.io',
                            database='mes',
                            user='cms',
                            password='1234')
        
        cursorMES = connMES.cursor()

        # master_data : MES의 기준정보 테이블
        master_data_sql = f"SELECT * FROM recipe_master_data WHERE recipe_id = '{recipe_id}' AND equipment_id = '{equipment_id}' AND param_id = '{param_id}'"
        cursorMES.execute(master_data_sql)
        mes = cursorMES.fetchone()
        cursorMES.close()
        connMES.close()

        if param_level == mes[7] and usl == mes[3] and lsl == mes[4] and usl_interlock_action == mes[5] and lsl_interlock_action == mes[6]:
            print("FDC 설비 데이터가 MES 기준 정보와 일치합니다.")

        if param_level != mes[7]:
            update_sql = f"UPDATE param SET param_level = '{mes[7]}' WHERE param_id = '{param_id}' AND equipment_id = '{equipment_id}'"
            cursor.execute(update_sql)
            conn.commit()
            print("Data Change : param_level")
        if usl != mes[3]:
            update_sql = f"UPDATE recipe_test SET usl = '{mes[3]}' WHERE recipe_id = '{recipe_id}'"
            cursor.execute(update_sql)
            conn.commit()
            print("Data Change : usl")
        if lsl != mes[4]:
            update_sql = f"UPDATE recipe_test SET lsl = '{mes[4]}' WHERE recipe_id = '{recipe_id}'"
            cursor.execute(update_sql)
            conn.commit()
            print("Data Change : lsl")
        if usl_interlock_action != mes[5]:
            update_sql = f"UPDATE recipe_test SET usl_interlock_action = '{mes[5]}' WHERE recipe_id = '{recipe_id}'"
            cursor.execute(update_sql)
            conn.commit()
            print("Data Change : usl_interlock_action")
        if lsl_interlock_action != mes[6]:
            update_sql = f"UPDATE recipe_test SET lsl_interlock_action = '{mes[6]}' WHERE recipe_id = '{recipe_id}'"
            cursor.execute(update_sql)
            conn.commit()
            print("Data Change : lsl_interlock_action")

        cursor.close()
        conn.close()
    except:
        print("Can Not Access : FDC DB to MES DB")



# storage에 할당된 Data를 DB 저장하고 flush
def intervalSave():
    global storage 
    
    print("--------------Bulk Insert Start--------------")

    conn = psycopg2.connect(host='k8a201.p.ssafy.io',
                            database='fdc',
                            user='cms',
                            password='1234')

    param_sql = "INSERT INTO param_log (created_at, param_value, equipment_id, param_id, recipe_id, is_interlock) VALUES (%s, %s, %s, %s, %s, %s)" 

    with conn:
            with conn.cursor() as cur:
                    for i in range(len(storage)):
                            cur.execute(param_sql, (storage[i]['created_at'], storage[i]['data_value'],storage[i]['equipment_id'],storage[i]['param_id'],storage[i]['recipe_id'],storage[i]['is_interlock'])) 
                    conn.commit() 
    
    storage = [] 
    print("--------------Bulk Insert Completed--------------")



# MES 서버에 인터락 설비 데이터 전송
def MESClient():
    global temp
    while True:
        if len(temp) > 0:
            mes_client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            mes_addr = ("k8a201.p.ssafy.io", mes_port)
            with mutex:
                mes_client_socket.connect(mes_addr)
            print("MES Client 소켓 연결")
            while temp!=[]:
                # mutex.acquire()
                with mutex:
                    temp_str = json.dumps(temp[0])
                    # print("temp_str : ", temp_str)
                    temp = []
                print("temp_str : ", temp_str)
                temp_str = temp_str.encode()
                length = len(temp_str)
                mes_client_socket.sendall(length.to_bytes(1024, byteorder='little'))
                mes_client_socket.sendall(temp_str)
                print("MES Client 요청 송신 완료")
                with mutex:
                    response = mes_client_socket.recv(1024)
                # mutex.release()



def FDC():
    Server_thread = threading.Thread(target=FDCServer)
    Client_thread = threading.Thread(target=MESClient)
    Server_thread.start()	
    print("SIM Server Thread start...")
    Client_thread.start()
    print("MES Client Thread start...")

    while True:

        if not Server_thread.is_alive():
            Server_thread.start()
            print("서버 소켓 스레드 재실행")

        if not Client_thread.is_alive():
            Client_thread.start()
            print("클라이언트 소켓 스레드 재실행")

        time.sleep(0.1)


FDC()

# TODO SIM 서버랑 SIM 클라 연결 확인하기