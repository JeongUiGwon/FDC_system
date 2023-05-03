import socket
import threading

mes_port = 8887

def MESHandleConnection(conn, addr):
    while True:
        data = conn.recv(1024)
        print(data)
        if not data:
            break
        conn.sendall(data)
    conn.close()

def MES():
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(("172.26.6.41", mes_port))
    server_socket.listen(1)
    try:
        while True:
            conn, addr = server_socket.accept()
            threading.Thread(target=MESHandleConnection, args=(conn, addr)).start()
    finally:
        print("die")
        server_socket.close()

MES()
