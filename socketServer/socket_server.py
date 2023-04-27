from socket import *;	
import socket, threading;	
 	

def binder(client_socket, addr):	
  print('Client Join!! ', addr);	
  try:	
    while True:	
      data = client_socket.recv(1024);	
      length = int.from_bytes(data, "little"); 
      data = client_socket.recv(length);	
      msg = data.decode();	
      if (length > 0):
        print('msg : ', msg ,' / Received from : ', addr);	
 		
      msg = "상빈 하이 : " + msg;	
      data = msg.encode();		
      length = len(data);	
      client_socket.sendall(length.to_bytes(1024, byteorder='little'));		
      client_socket.sendall(data);	
  except:	
    print("Client Exit~~ " , addr);	
  finally:		
    client_socket.close();	
 	
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM);	
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1); 
server_socket.bind(('172.26.6.41', 8888));	
server_socket.listen();	
 	
try:		
  while True:		
    client_socket, addr = server_socket.accept();	
    th = threading.Thread(target=binder, args = (client_socket,addr));	
    th.start();	
except:	
  print("server");	
finally:	
  server_socket.close()