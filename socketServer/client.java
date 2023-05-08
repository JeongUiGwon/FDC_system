import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.io.IOException;

 
public class Client {
    
  public static void main(String... args) {
    try (Socket client = new Socket()) {
      InetSocketAddress ipep = new InetSocketAddress("k8a201.p.ssafy.io", 8889);      
      client.connect(ipep);
      try (OutputStream sender = client.getOutputStream(); InputStream receiver = client.getInputStream();) {
        String msg = "send to mes test message";
        System.out.println(msg);
        byte[] data = msg.getBytes("UTF-8");
        ByteBuffer b = ByteBuffer.allocate(4);
        b.order(ByteOrder.LITTLE_ENDIAN);
        b.putInt(data.length);
        sender.write(b.array(), 0, 4);
        sender.write(data);
          
        data = new byte[4];
        receiver.read(data, 0, 4);
        ByteBuffer bb = ByteBuffer.wrap(data);
        bb.order(ByteOrder.LITTLE_ENDIAN);
        int length = bb.getInt();
        data = new byte[length];
        receiver.read(data, 0, length);
        msg = new String(data, "UTF-8");
        System.out.println(msg);
      }
    } catch (IOException e) {
        // 데이터 전송 중 문제가 발생한 경우 처리
        e.printStackTrace();
      }
     catch (Throwable e) {
      // 기타 예외 처리
      e.printStackTrace();
    }
  }
}