import socket, threading, json, pymysql, time

storage = []
save_interval = 60
last_save_time = time.time()

def main(client_socket, addr):	
    global storage, last_save_time
    print('Join : ', addr)

    try:	
        while True:	
            data = client_socket.recv(1024)	
            length = int.from_bytes(data, "little") 
            data = client_socket.recv(length)	
            msg = data.decode()	
            if (length > 0):
                print(addr, ' 에서', msg,' 를 보냈습니다.') 
                data = json.loads(data)
                storage.append(data)
                # interlock check
                conn = pymysql.connect(host='172.26.6.41',
                            user='cms',
                            password='11111111',
                            db='minki',
                            charset='utf8')
                cursor = conn.cursor()
                val = data["data_value"]
                recipe_id = data["recipe_id"]
                cause_equip_id = data['equipment_id']
                created_at = data["created_at"]
                lot_id = data["lot_id"]
                param_id = data["param_id"]
                recipe_sql = f'SELECT * FROM recipe_test WHERE recipe_id = "{recipe_id}"'
                
                cursor.execute(recipe_sql)
                recipe = cursor.fetchone()
                cursor.close()
                lsl = recipe[2]
                usl = recipe[3]
            
                if val < lsl:
                    interlock_type = recipe[4]    
                elif val > usl:
                    interlock_type = recipe[5]
                else:
                    interlock_type = 0

                if interlock_type == 0:
                    print("check!!!")
                    conn.close()
                else:
                    print("--------------interlock found--------------")
                    upper_limit = usl
                    data_value = val
                    lower_limit = lsl
                    cause_equip_id = cause_equip_id
                    equip_sql = f'SELECT * FROM equipment_test WHERE equipment_id = "{cause_equip_id}"'
                    cursor = conn.cursor()
                    cursor.execute(equip_sql)
                    equip = cursor.fetchone()
                    cursor.close()
                    equipment_id = equip[1]
                    
                    cnt_sql = f'SELECT * FROM interlock_log_test WHERE equipment_id = "{equipment_id}" AND param_id = "{param_id}" AND recipe_id = "{recipe_id}"'
                    cursor = conn.cursor()
                    cursor.execute(cnt_sql)
                    cnt = cursor.fetchall()
                    out_count = len(cnt)
                    cursor.close()

                    insert_sql = f"INSERT INTO interlock_log_test (created_at, interlock_type, upper_limit, data_value, lower_limit, cause_equip_id, equipment_id, lot_id, param_id, recipe_id, out_count) VALUES ('{created_at}','{interlock_type}','{upper_limit}','{data_value}','{lower_limit}','{cause_equip_id}','{equipment_id}','{lot_id}','{param_id}','{recipe_id}','{out_count}')"
                    cursor = conn.cursor()
                    cursor.execute(insert_sql)
                    conn.commit()
                    cursor.close()
                    conn.close()
                    
                     
            msg = "서버에서 " + msg + " 의 내용을 받았습니다."	
            data = msg.encode()		
            length = len(data)	
            client_socket.sendall(length.to_bytes(1024, byteorder='little'))		
            client_socket.sendall(data)
            # intervalSave threading
            elapsed_time = time.time() - last_save_time
            if elapsed_time > save_interval:
                 th2 = threading.Thread(target=intervalSave)
                 th2.start()
                 last_save_time = time.time() 
    except:	
        print("Exit : " , addr)	
    finally:		
        client_socket.close() 



def intervalSave():
    global storage 
    
    conn = pymysql.connect(host='172.26.6.41',
                            user='cms',
                            password='11111111',
                            db='minki',
                            charset='utf8') 

    param_sql = "INSERT INTO param_log_test (created_at, data_value, equipment_id, param_id, recipe_id) VALUES (%s, %s, %s, %s, %s)" 

    with conn:
            with conn.cursor() as cur:
                    for i in range(len(storage)):
                            cur.execute(param_sql, (storage[i]['created_at'], storage[i]['data_value'],storage[i]['equipment_id'],storage[i]['param_id'],storage[i]['recipe_id'])) 
                    conn.commit() 
    
    storage = [] 


server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)	
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
server_socket.bind(('172.26.6.41', 8888))	
server_socket.listen()	


try:		
    while True:		
        client_socket, addr = server_socket.accept()	
        th1 = threading.Thread(target=main, args = (client_socket,addr))	
        th1.start()	
except:	
    print("server")	
finally:	
    server_socket.close() 
