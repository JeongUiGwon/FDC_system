import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.time.LocalDateTime;

public class newClient {

  // lot 관리를 위해 선언하는 글로벌변수
  static int lot_id = 1;
  static int lot_cnt = 0;

  // 망해버린 lot_id 함수. 지워도 상관없는 부분임
  // public void lotStart() {
  //   lot_cnt = lot_cnt + 1;
  //   System.out.println("lot_cnt: "+ lot_cnt);
  //   System.out.println("lot_id: "+ lot_id);
  //   if(lot_cnt > 3){
  //     lot_id = lot_id + 1;
  //     lot_cnt = 0;
  //   }
  // }


/* java참고사항
 * main함수는 여러개의 string을 arguments로 받아올 수 있음
 * SIM에서 main함수 호출 시 newClient.main("a", "b", "c", ...) 와 같은 형태로 호출하고
 * 이 때 갖고온 arguments는 args[0] = "a", args[1] = "b", args[2] = "c" ... 와 같이 불러올 수 있음
 */
  
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
      InetSocketAddress ipep = new InetSocketAddress("k8a201.p.ssafy.io", 8889);
      // 소켓 접속
      client.connect(ipep);
      // 소켓이 접속이 완료되면 inputstream과 outputstream을 받기
      try (OutputStream sender = client.getOutputStream(); InputStream receiver = client.getInputStream();) {
        
        // 전송할 메시지를 작성

        // 1. 변수화하기 (SIM에서 main함수 호출 시 parameter(args)으로 전달)
        LocalDateTime datetime = LocalDateTime.now();
        String created_at = datetime.toString();
        double data_value = Double.parseDouble(args[0]);
        String equipment_id = args[1];
        // String equipment_name = args[2];
        // int lot_id = Integer.parseInt("1");
        String param_id = args[2];
        String recipe_id = args[3];
        // String equipment_mode = args[5];
        // String equipment_status = args[6];


        // 노드(설비)를 늘리거나 param 및 기준정보를 추가한다면 FDC DB와 협의해서 이름을 통일해야 통신이 가능함
        // 현재 통일된 이름은 아래와 같고 추가 또는 변경 시 복붙 편하게 아래와 같이 적어놓는 것 추천

        /*           설비id           항목id                레시피id
         * node 1  "9988YSB0"   "O4I2WWF2BUKK52U"   "SQK24INRJSP2FDFQ322K"
         * node 2  "8210JEK6"   "X8S5OWN7NWIS11T"   "OSO62ONWNWS8OOWN017P"
         * node 3  "6272CMK6"   "N7I6IXN7OSNS22O"   "NNX12IIWNWH1PPQX733M"
         */


         // 2. 변수화된 데이터를 json형태로 합쳐 String으로 선언
         // Json 생성 라이브러리가 있긴 한데 java는 파이썬과 다르게 jar파일을 받아서 어디 넣어줘야하는 그런게 있어서
         // 번거로울 것 같아 그냥 노가다했음
         // 나중에 완성될 때 쯤 바꿔야될 것 같으면 제가 바꿀게요
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
