import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.InetSocketAddress;

public class TcpServerExample {

  public static int tcpServerPort = 9999;

  public static void main(String[] args) {
      new TcpServerExample(tcpServerPort);
  }

  public TcpServerExample(int portNo) {
      tcpServerPort = portNo;
      try {
          // ServerSocket 생성
          ServerSocket serverSocket = new ServerSocket();
          serverSocket.bind(new InetSocketAddress(tcpServerPort));
          System.out.println("Starting tcp Server: " + tcpServerPort);
          System.out.println("[ Waiting ]\n");
          while (true) {
              // socket -> bind -> listen socket 클래스 내부에 구현되어 있음
              Socket socket = serverSocket.accept();
              System.out.println("Connected " + socket.getLocalPort() + " Port, From " + socket.getRemoteSocketAddress().toString() + "\n");
              // Thread
              Server tcpServer = new Server(socket);
              tcpServer.start();
          }
      } catch (IOException io) {
          io.getStackTrace();
      }
  }

  public class Server extends Thread {
      private Socket socket;

      public Server(Socket socket) {
          this.socket = socket;
      }

      public void run() {
          try {
              while (true) {
                  // Socket에서 가져온 출력스트림
                  OutputStream os = this.socket.getOutputStream();
                  DataOutputStream dos = new DataOutputStream(os);
                  // 저장을 위한 출력스트림
                  OutputStream fos = new FileOutputStream("C:/Users/SSAFY/Desktop/gitlab/자율/outputTest.txt");

                  // Socket에서 가져온 입력스트림
                  InputStream is = this.socket.getInputStream();
                  DataInputStream dis = new DataInputStream(is);

                  // read int
                  int recieveLength = dis.readInt();

                  // receive bytes
                  byte receiveByte[] = new byte[recieveLength];
                  dis.readFully(receiveByte, 0, recieveLength);
                  String receiveMessage = new String(receiveByte, "utf-8");
                  System.out.println("receiveMessage : " + receiveMessage);
                  System.out.println("[ Data Receive Success ]\n");
                  // 파일로 저장이왜안되지?????????????????????????????????????????????????????????
                  byte[] by = receiveMessage.getBytes();
                  fos.write(by);
                  fos.close();

                  // send bytes
                  String sendMessage = "I am Sangbin 나는 상빈이다 123";
                  byte[] sendBytes = sendMessage.getBytes("UTF-8");
                  int sendLength = sendBytes.length;
                  dos.writeInt(sendLength);
                  dos.write(sendBytes, 0, sendLength);
                  dos.flush();

                  System.out.println("sendMessage : " + sendMessage);
                  System.out.println("[ Data Send Success ]");
              }
          } catch (EOFException e) {
              // readInt()를 호출했을 때 더 이상 읽을 내용이 없으면 EOFException이 발생한다.
          } catch (IOException e) {
              e.printStackTrace();
          } finally {
              try {
                  if (this.socket != null) {
                      System.out.print("\n[ Socket closed ] ");
                      System.out.println("Disconnected :" + this.socket.getInetAddress().getHostAddress() + ":"
                              + this.socket.getPort());
                      this.socket.close();
                  }
              } catch (Exception e) {
              }
          }
      }
  }
}