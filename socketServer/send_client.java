import java.io.InputStream;
import java.io.OutputStream;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.io.IOException;
import java.time.LocalDateTime;
import java.text.SimpleDateFormat;
import java.util.Calendar;

// 최초 설비데이터를 보내주는 클라이언트

public class SendThread extends Thread {
	private SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
	private static Calendar start_time;
	private Calendar created_at;
	
	private String equipment_id;
	private String lot_id;
	private String param_id;
	private String recipe_id;
	private int cycle_count;
	private float start_value;
	private float value_term;
	private int delay_miliseconds;
	
	public SendThread(String... args) {
		if (start_time == null) {
			start_time = Calendar.getInstance();
		}
		
		equipment_id = args[0];
		lot_id = args[1];
		param_id = args[2];
		recipe_id = args[3];
		cycle_count = Integer.parseInt(args[4]);
		start_value = Float.parseFloat(args[5]);
		value_term = Float.parseFloat(args[6]);		
		Double elaspsed_time = Double.parseDouble(args[7]);
		
		delay_miliseconds = (int) (elaspsed_time * 1000);
		created_at = start_time;
		created_at.add(Calendar.MILLISECOND, delay_miliseconds);
	}

      @Override
      public void run() {
          try {
                // 서버 주소와 포트 번호
                String host = "k8A201.p.ssafy.io";
                int port = 8888;                
                
                // 서버 주소와 포트 번호를 지정하여 소켓 생성
                Socket socket = new Socket(host, port);
                System.out.println("소켓 생성");
                
                // 소켓에서 입출력을 위한 데이터 스트림 생성
                OutputStream outstream = socket.getOutputStream();
                InputStream instream = socket.getInputStream();
                
                // 서버로 메시지 전송
                OutputStream outwriter = socket.getOutputStream();

				// 현재 시간 string으로 출력
                String str_created_at = sdf.format(created_at.getTime());
                
                float data_value = (float) (Math.random() * value_term) + start_value;
                String str_data_value = Float.toString(data_value);
                
                String msg = String.format("{\"created_at\": \"%s\", \"data_value\": %s, \"equipment_id\": \"%s\", \"lot_id\": \"%s\", \"param_id\": \"%s\", \"recipe_id\": \"%s\"}", str_created_at, str_data_value, equipment_id, lot_id, param_id, recipe_id);
                
                for (int i = 1; i < cycle_count; i++) {
                	created_at.add(Calendar.MINUTE, 1);
                    str_created_at = sdf.format(created_at.getTime());                	
                	
                	data_value = (float) (Math.random() * value_term) + start_value;
                	str_data_value = Float.toString(data_value);
                	
                	msg += String.format("|{\"created_at\": \"%s\", \"data_value\": %s, \"equipment_id\": \"%s\", \"lot_id\": \"%s\", \"param_id\": \"%s\", \"recipe_id\": \"%s\"}", str_created_at, str_data_value, equipment_id, lot_id, param_id, recipe_id);
                }
                
                System.out.println("send : " + msg);
                byte[] data = msg.getBytes("UTF-8");
                ByteBuffer b = ByteBuffer.allocate(1024);
                b.order(ByteOrder.LITTLE_ENDIAN);
                b.putInt(data.length);
                outstream.write(b.array(), 0, 1024);
                outstream.write(data);                

                // 서버에서 보낸 응답을 읽어들임
                InputStream inreader = socket.getInputStream();
                data = new byte[1024];
                ByteBuffer bb = ByteBuffer.wrap(data);
                bb.order(ByteOrder.LITTLE_ENDIAN);
                int length = bb.getInt();
                data = new byte[length];
                inreader.read(data, 0, length);
                msg = new String(data, "UTF-8");
                System.out.println("received : " + msg);

                // 소켓 닫기
                socket.close();
                System.out.println("소켓 닫기");
                               
                
            } catch (IOException e) {
                e.printStackTrace();
                System.out.println(e);
            }
      }
}