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

  public void lotStart() {
    lot_cnt = lot_cnt + 1;
    System.out.println("lot_cnt: "+ lot_cnt);
    System.out.println("lot_id: "+ lot_id);
    if(lot_cnt > 3){
      lot_id = lot_id + 1;
      lot_cnt = 0;
    }
  }

  public static void main(String... args) {
    // 소켓을 선언한다.
    try (Socket client = new Socket()) {
      // 소켓에 접속하기 위한 접속 정보를 선언한다.
      InetSocketAddress ipep = new InetSocketAddress("k8a201.p.ssafy.io", 8888);
      // 소켓 접속!
      client.connect(ipep);
      // 소켓이 접속이 완료되면 inputstream과 outputstream을 받는다.
      try (OutputStream sender = client.getOutputStream(); InputStream receiver = client.getInputStream();) {
        // 메시지는 for 문을 통해 10번 메시지를 전송한다.
        
        // 전송할 메시지를 작성한다.
        // double param_value = 11.121;
        // String equipment_id = 9988YSB0;
        // String param_id = O4I2WWF2BUKK52U; // DOWN
        // String recipe_id = SQK24INRJSP2FDFQ322K;

        // 변수화하기 (함수 호출 시 param으로 전달)
        LocalDateTime datetime = LocalDateTime.now();

        String created_at = datetime.toString();
        double data_value = Double.parseDouble(args[0]);
        String equipment_id = args[1];
        // String equipment_name = args[2];
        // int lot_id = Integer.parseInt("1");
        String param_id = args[2]; // DOWN
        String recipe_id = args[3];
        // String equipment_mode = args[5];
        // String equipment_status = args[6];

        // String msg = String.format(
        //   "{\"created_at\": \"%s\", 
        //   \"param_value\": %f, 
        //   \"equipment_id\": \"%s\", 
        //   \"param_id\": \"%s\", 
        //   \"recipe_id\": \"%s\"
        // }", created_at, param_value, equipment_id, param_id, recipe_id);
        String msg = String.format("{\"created_at\": \"%s\", \"data_value\": %f, \"equipment_id\": \"%s\", \"lot_id\": \"%d\", \"param_id\": \"%s\", \"recipe_id\": \"%s\"}", created_at, data_value, equipment_id, lot_id, param_id, recipe_id);
        // String msg = "{\"equipment_Id\": 1, \"equiptment_Name\": \"권취\", \"equipment_State\": \"RUN\"}";
        
        // string을 byte배열 형식으로 변환한다.
        byte[] data = msg.getBytes("UTF-8");
        // ByteBuffer를 통해 데이터 길이를 byte형식으로 변환한다.
        ByteBuffer b = ByteBuffer.allocate(1024);
        // byte포멧은 little 엔디언이다.
        b.order(ByteOrder.LITTLE_ENDIAN);
        b.putInt(data.length);
        // 데이터 길이 전송
        sender.write(b.array(), 0, 1024);
        // 데이터 전송
        sender.write(data);
        
        data = new byte[1024];
        // 데이터 길이를 받는다.
        receiver.read(data, 0, 1024);
        // ByteBuffer를 통해 little 엔디언 형식으로 데이터 길이를 구한다.
        ByteBuffer bb = ByteBuffer.wrap(data);
        bb.order(ByteOrder.LITTLE_ENDIAN);
        int length = bb.getInt();
        // 데이터를 받을 버퍼를 선언한다.
        data = new byte[length];
        // 데이터를 받는다.
        receiver.read(data, 0, length);
        
        // byte형식의 데이터를 string형식으로 변환한다.
        msg = new String(data, "UTF-8");
        // 콘솔에 출력한다.
        System.out.println(msg);
      }
    } catch (Throwable e) {
      e.printStackTrace();
    }
  }
}