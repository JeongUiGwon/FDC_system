import socket
import threading
import logging
import time
import json


mes_port = 8887
sim_port = 8889
temp = []

def MESServer():
    global temp
    mutex = threading.Lock()
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    server_socket.bind(("172.26.6.41", mes_port))
    server_socket.listen(1)

    print("MES - FDC Server Start...")

    while True:
        with mutex:
            conn, addr = server_socket.accept()
        print('Join : ', addr)

        try:
            while True:
                with mutex:
                    data = conn.recv(1024)
                    length = int.from_bytes(data, 'little')
                    data = conn.recv(length)   

                msg = data.decode()
                msg = json.loads(msg)
                
                if len(msg) > 0:
                    mutex.acquire()
                    temp.append(msg)
                    mutex.release()
                    print(addr, ' : ', msg)

                else:
                    msg = "no msg required"
                    mutex.release()

                msg = msg.encode()
                length = len(msg)

                with mutex:
                    conn.sendall(length.to_bytes(1024, byteorder='little'))
                    conn.sendall(msg)
                print('Exit : ', addr)

        except Exception as e:
            logging.error('Error occurred: %s', str(e))

        finally:
            conn.close()




def SIMServer():
    global temp
    mutex = threading.Lock()
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    client_socket.bind(("172.26.6.41", sim_port))
    client_socket.listen(1)

    print("SIM - MES Server Start....")
    
    while True:
        with mutex:
            conn, addr = client_socket.accept()
            print('Join : ', addr)

        try:  
            with mutex:
                data = conn.recv(1024)
                length = int.from_bytes(data, 'little')
                data = conn.recv(length)
            
            if temp == []:
                msg1 = "Interlock not found"
                data1 = msg1.encode()
                length = len(data1)

                with mutex:
                    conn.sendall(length.to_bytes(1024, byteorder='little'))
                    conn.sendall(data1)
                print("send to sim : ", data1)
                print('Exit : ', addr)

            else:
                with mutex:
                    msg2 = json.dumps([data["equipment_id"] for data in temp])
                    temp = []

                msg2 = "Invalid equipment ID found : " + msg2
                length = len(msg2.encode())

                with mutex:
                    conn.sendall(length.to_bytes(1024, byteorder='little'))
                    conn.sendall(msg2.encode())
                print("send to sim : ", msg2)
                print('Exit : ', addr)
                
        except Exception as e:
            logging.error('Error occurred: %s', str(e))

        finally:
            conn.close()



def MES():
    Client_thread = threading.Thread(target=SIMServer)
    Server_thread = threading.Thread(target=MESServer)

    Client_thread.start()
    Server_thread.start()

    while True:
        if not Server_thread.is_alive():
            Server_thread.start()
            print("서버 소켓 스레드 재실행")

        if not Client_thread.is_alive():
            Client_thread.start()
            print("클라이언트 소켓 스레드 재실행")

        time.sleep(0.1)

MES()