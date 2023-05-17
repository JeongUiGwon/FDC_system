import socket
import threading
import json
import time
import psycopg2
import datetime as dt

temp_port = 8886
mes_port = 8887
mutex = threading.Lock()

# Socket 으로 받은 Data를 1분간 할당할 Memory
storage = []
temp = []
# intervalSave 함수를 th2로 돌릴 단위 시간(초)
save_interval = 10
last_save_time = time.time()


def FDCServer():	
    global storage, last_save_time
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)	
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    server_socket.bind(('172.26.6.41', temp_port))	
    server_socket.listen(1)	
    print("temp Server Socket listening...")

    while True:

        try:
            # 접속 상태에서 메세지 수신 무한 대기, 접속 끊기면 except 발생
            # while True:	
            with mutex:
                client_socket, addr = server_socket.accept()
            print('Join : ', addr)
            # 1024 byte 데이터 수신 대기
            print("data receiving....")

            with mutex:
                data = client_socket.recv(1024)	
                # little 엔디언으로 byte에서 int로 변환
                length = int.from_bytes(data, "little") 
                # 다시 데이터 수신 대기
                data = client_socket.recv(length)
            # 수신된 데이터 문자열 형태로 Decoding	
            msg = data.decode()

            if (length > 0):
                list_data =  msg.split('|')
                # Data dict 형변환 
                                    
                for item in list_data:
                    # print("----------------")
                    # print(item)
                    # print("----------------")
                    json_data = json.loads(item)
                    storage.append(json_data)
                    
                # Client 에게 메세지 송신 (echo), 수신과 서순 반대
                msg = "FDC : " + msg
                msg = msg.encode()
                length = len(msg)

                with mutex:
                    client_socket.sendall(length.to_bytes(1024, byteorder='little'))		
                    client_socket.sendall(msg)                    

        except:	
            print("Exit : " , addr)	

        finally:		
            client_socket.close() 



def intervalSave():
    global storage
    global save_interval
    global last_save_time
    while True:

        if storage == []: 
            continue

        elapsed_time = time.time() - last_save_time
        if elapsed_time > save_interval:
            print("--------------Bulk Insert Start--------------")
            
            conn = psycopg2.connect(host='k8a201.p.ssafy.io',
                                    database='fdc',
                                    user='cms',
                                    password='1234')

            param_sql = "INSERT INTO full_pattern_log (onesDigit, data_value) VALUES (%s, %s)" 

            with conn:
                    with conn.cursor() as cur:
                            for i in range(len(storage)):
                                    print("storage[i] : ",storage[i])
                                    cur.execute(param_sql, (storage[i]['onesDigit'], storage[i]['data_value'])) 
                            conn.commit() 
            
            storage = [] 
            print("--------------Bulk Insert Completed--------------")
            
            last_save_time = time.time()



def FDC():
    Server_thread = threading.Thread(target=FDCServer)
    DBSave_thread = threading.Thread(target=intervalSave)
    Server_thread.start()
    DBSave_thread.start()

    while True:

        if not Server_thread.is_alive():
            Server_thread.start()
            print("서버 소켓 스레드 재실행")

        if not DBSave_thread.is_alive():
            DBSave_thread.start()
            print("디비 스레드 재실행")

        time.sleep(0.1)


FDC()