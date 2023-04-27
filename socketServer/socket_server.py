import socket, threading, json, pymysql;

storage = []; 

def binder(client_socket, addr):	
    global storage; 
    print('Join : ', addr);	
    try:	
        while True:	
            data = client_socket.recv(1024);	
            length = int.from_bytes(data, "little"); 
            data = client_socket.recv(length);	
            msg = data.decode();	
            if (length > 0):
                print(addr, ' 에서', msg,' 를 보냈습니다.'); 
                data = json.loads(data);  
                storage.append(data); 
                
            msg = "서버에서 " + msg + " 의 내용을 받았습니다.";	
            data = msg.encode();		
            length = len(data);	
            client_socket.sendall(length.to_bytes(1024, byteorder='little'));		
            client_socket.sendall(data); 
    except:	
        print("Exit : " , addr);	
    finally:		
        client_socket.close(); 



def saveFile():
    global storage; 
    
    conn = pymysql.connect(host='172.26.6.41',
                            user='cms',
                            password='11111111',
                            db='minki',
                            charset='utf8'); 

    sql = "INSERT INTO param_log_test (datetime, param_value, equipment_id, param_id, recipe_id) VALUES (%s, %s, %s, %s, %s)"; 

    with conn:
            with conn.cursor() as cur:
                    for i in range(len(storage)):
                            cur.execute(sql, (storage[i]['datetime'],storage[i]['param_value'],storage[i]['equipment_id'],storage[i]['param_id'],storage[i]['recipe_id'])); 
                    conn.commit(); 
    
    storage = []; 
    threading.Timer(60, saveFile).start(); 


server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM);	
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1); 
server_socket.bind(('172.26.6.41', 8888));	
server_socket.listen();	


try:		
    while True:		
        client_socket, addr = server_socket.accept();	
        th1 = threading.Thread(target=binder, args = (client_socket,addr));	
        th2 = threading.Thread(target=saveFile); 
        th1.start();	
        th2.start(); 
except:	
    print("server");	
finally:	
    server_socket.close(); 