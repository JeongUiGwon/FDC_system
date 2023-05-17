import java.io.*;
import java.net.*;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;

// 인터렉션 메세지를 받아오는 클라이언트

public class ReceiveThread {
	static private Main myMainAgent;
	  // 매개변수 없는 생성자
	public ReceiveThread() {}
	  // Main에 접근할 수 있는 생성자. 시뮬레이터에선 this를 넣음
	public ReceiveThread(Main mainAgent) {
		  this.myMainAgent = mainAgent;
	}

	
    public static void main(String... args) {
        try {
            // 서버 주소와 포트 번호
            String host = "k8A201.p.ssafy.io";
            int port = 8889;
            
            
                
            // 서버 주소와 포트 번호를 지정하여 소켓 생성
            Socket socket = new Socket(host, port);
            System.out.println("소켓 생성");

            // 소켓에서 입출력을 위한 데이터 스트림 생성
            OutputStream outstream = socket.getOutputStream();
            InputStream instream = socket.getInputStream();
            
            // 서버로 메시지 전송
            OutputStreamWriter outwriter = new OutputStreamWriter(outstream);
            String msg = "From SIM to MES : require the interaction data";  
            System.out.println("send : " + msg);
            byte[] data = msg.getBytes("UTF-8");
            ByteBuffer b = ByteBuffer.allocate(1024);
            b.order(ByteOrder.LITTLE_ENDIAN);
            b.putInt(data.length);
            outstream.write(b.array(), 0, 1024);
            outstream.write(data);

            // 서버에서 보낸 응답을 읽어들임
            //InputStreamReader inreader = new InputStreamReader(instream);
            DataInputStream dis = new DataInputStream(instream);
                      
            data = new byte[1024];
            // 데이터 길이 수신
            instream.read(data, 0, 1024);
            // ByteBuffer를 통해 little endian 형식으로 데이터 길이 얻기
            ByteBuffer bb = ByteBuffer.wrap(data);
            bb.order(ByteOrder.LITTLE_ENDIAN);
            int length = bb.getInt();
            // 데이터를 받을 버퍼를 선언
            data = new byte[length];
            // 데이터를 받음
            instream.read(data, 0, length);

            msg = new String(data, "UTF-8");
            System.out.println("received : " + msg);
            
            // 소켓 닫기
            socket.close();
            System.out.println("소켓 닫기");  
            
            // interlock 발생
            if (msg.equals("Interlock not found")) {
            	//mixer_speed 변경
            	//myMainAgent.set_TotalSpeed(1);
            	//System.out.println(myMainAgent.mixer_speed);
            } else {
            	//coater_speed 변경
            	myMainAgent.set_TotalSpeed(0);
            }

                        
            
            
	    } catch (IOException e) {
	            e.printStackTrace();
	            System.out.println(e);
	    }
	}
}

// 포팅 예시 (startup에 time 고정 필요)

/*System.out.println("Factory Destory ,,,");
ReceiveThread thread2 = new ReceiveThread(this);
thread2.main();*/


