import socket
import threading
import select

mutex = threading.Lock()
mes_port = 8887
sim_port = 8889
temp = []

def MESServer():
    global temp
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    server_socket.bind(("172.26.6.41", mes_port))
    server_socket.listen(1)
    while True:
        mutex.acquire()
        conn, addr = server_socket.accept()
        mutex.release()
        try:
            while True:
                data = conn.recv(1024)
                if data:
                    temp.append(data)
                print(addr, ' : ', data)
                if not data:
                    data = "no data"
                conn.sendall(data)
        finally:
            conn.close()




def SIMServer():
    global temp
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) 
    client_socket.bind(("172.26.6.41", sim_port))
    client_socket.listen(1)
    while True:
        mutex.acquire()
        conn, addr = client_socket.accept()
        mutex.release()
        try:  
            while True:
                data = conn.recv(1024)
                length = int.from_bytes(data, 'little')
                data = conn.recv(length)
                msg = data.decode()
                if (length > 0):
                    print('sim  : ', addr, ' : ', msg)
                    msg = "SIM에서 수신 : " + msg
                if temp!=[]:
                    temp_str = temp[0]
                    temp = []
                    msg = temp_str
                    print('INTERACTION : ', msg)
                    length = len(msg)
                    conn.sendall(length.to_bytes(4, byteorder='little'))
                    conn.sendall(msg)

                    # 소켓이 쓰기 가능한 상태인지 확인
                    # try:
                    #     # select() 함수를 사용하여 소켓이 쓰기 가능한 상태인지 확인
                    #     select_res = select.select([], [conn], [], 5)
                    #     if select_res[1]:
                    #         # 소켓이 쓰기 가능한 상태이므로 데이터 전송
                            
                    # except:
                    #     print("conn closed")
                else:
                    msg = "interlock not found"
                    msg = msg.encode()
                    length = len(msg)
                    conn.sendall(length.to_bytes(4, byteorder='little'))
                    conn.sendall(msg)
        except Exception as e:
            print(e)
        finally:
            conn.close()



def MES():
    Client_thread = threading.Thread(target=SIMServer)
    Server_thread = threading.Thread(target=MESServer)
    Client_thread.start()
    Server_thread.start()
    while True:
        if not Server_thread.is_alive():
            Server_thread = threading.Thread(target=MESServer)
            Server_thread.start()
            print("서버 소켓 스레드 재실행")
        if not Client_thread.is_alive():
            Client_thread = threading.Thread(target=SIMServer)
            Client_thread.start()
            print("클라이언트 소켓 스레드 재실행")


MES()