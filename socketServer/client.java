/* 
anylogic simulator 내장 실행 클래스
클래스는 2개로, agent마다 각각 호출
*/



import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.time.LocalDateTime;
import java.util.concurrent.TimeUnit;

public class newClient {

  // lot 관리를 위해 선언하는 글로벌변수
  static int lot_id = 1;
  static int lot_cnt = 0;

  // Main agent에 대한 참조 변수 생성
  static private Main myMainAgent;
  // 매개변수 없는 생성자
  public newClient() {}
  // Main에 접근할 수 있는 생성자. 시뮬레이터에선 this를 넣음
  public newClient(Main mainAgent) {
	  this.myMainAgent = mainAgent;
  }
  
  public static void main(String... args) {
	// 소켓을 선언
    try (Socket client = new Socket()) {
      // 소켓에 접속하기 위한 접속 정보를 선언
      InetSocketAddress ipep = new InetSocketAddress("k8a201.p.ssafy.io", 8888);
      // 소켓 접속
      client.connect(ipep);
      // 소켓이 접속이 완료되면 inputstream과 outputstream을 받기
      try (OutputStream sender = client.getOutputStream(); InputStream receiver = client.getInputStream();) {
    	// 전송할 메시지를 작성

          // 1. 변수화하기 (SIM에서 main함수 호출 시 parameter(args)으로 전달)
          LocalDateTime datetime = LocalDateTime.now().plusSeconds(0);
          String created_at = datetime.toString();
          double data_value = Double.parseDouble(args[0]);
          String equipment_id = args[1];
          // String equipment_name = args[2];
          // int lot_id = Integer.parseInt("1");
          String param_id = args[2];
          String recipe_id = args[3];
          
          String msg = String.format("{\"created_at\": \"%s\", \"data_value\": %f, \"equipment_id\": \"%s\", \"lot_id\": \"%d\", \"param_id\": \"%s\", \"recipe_id\": \"%s\"}", created_at, data_value, equipment_id, lot_id, param_id, recipe_id);
          
          
          // string을 byte배열 형식으로 변환
          byte[] data = msg.getBytes("UTF-8");
          // ByteBuffer를 통해 데이터 길이를 byte형식으로 변환
          ByteBuffer b = ByteBuffer.allocate(1024);
          // byte포멧은 little_endian
          b.order(ByteOrder.LITTLE_ENDIAN);
          b.putInt(data.length);
          // 데이터 길이 전송
          sender.write(b.array(), 0, 1024);
          // 데이터 전송
          sender.write(data);
          
          data = new byte[1024];
          // 데이터 길이 수신
          receiver.read(data, 0, 1024);
          // ByteBuffer를 통해 little endian 형식으로 데이터 길이 얻기
          ByteBuffer bb = ByteBuffer.wrap(data);
          bb.order(ByteOrder.LITTLE_ENDIAN);
          int length = bb.getInt();
          // 데이터를 받을 버퍼를 선언
          data = new byte[length];
          // 데이터를 받음
          receiver.read(data, 0, length);
          
          // byte형식의 데이터를 string형식으로 변환
          msg = new String(data, "UTF-8");
          // interlock 발생
          if (msg.equals("9988YSB0 interlock")) {
          	//mixer_speed 변경
          	myMainAgent.set_mixer_speed(0);
          	//System.out.println(myMainAgent.mixer_speed);
          } else if (msg.equals("8210JEK6 interlock")) {
          	//coater_speed 변경
          	myMainAgent.set_coater_speed(0);
          } else if (msg.equals("6272CMK6 interlock")) {
          	//press_speed 변경
          	myMainAgent.set_press_speed(0);
          }
          // 콘솔에 출력
          System.out.println(msg);
      }
    } catch (Throwable e) {
      e.printStackTrace();
    }
  }
}




import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.io.IOException;

 
public class SecondClient {
	
  static private Main myMainAgent;
  public SecondClient() {}
  public SecondClient(Main mainAgent) {
	this.myMainAgent = mainAgent;
  }
    
  public static void main(String... args) {
    try (Socket client = new Socket()) {
      InetSocketAddress ipep = new InetSocketAddress("k8a201.p.ssafy.io", 8889);      
      client.connect(ipep);
      try (OutputStream sender = client.getOutputStream(); InputStream receiver = client.getInputStream();) {
        String msg = "From SIM to MES : require the interaction data";        
        byte[] data = msg.getBytes("UTF-8");
        ByteBuffer b = ByteBuffer.allocate(1024);
        b.order(ByteOrder.LITTLE_ENDIAN);
        b.putInt(data.length);
        sender.write(b.array(), 0, 1024);
        sender.write(data);
        data = new byte[1024];
        receiver.read(data, 0, 1024);
        ByteBuffer bb = ByteBuffer.wrap(data);
        bb.order(ByteOrder.LITTLE_ENDIAN);
        int length = bb.getInt();
        data = new byte[length];
        receiver.read(data, 0, length);
        msg = new String(data, "UTF-8");
        System.out.println(msg);
      }
    }  catch (Throwable e) {
      e.printStackTrace();
    }
  }
}