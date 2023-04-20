import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_for_interlock_log():
    interlock_log_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    interlock_id = equipment_id
    state = random.randint(0, 1)
    start_time = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    end_time = start_time + timedelta(hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    start_time_str = start_time.strftime('%Y-%m-%d %H:%M:%S')
    end_time_str = end_time.strftime('%Y-%m-%d %H:%M:%S')

    return (interlock_log_id, equipment_id, interlock_id, state, start_time_str, end_time_str)

config = {
    'user': 'tyms0503',
    'password': '11111111',
    'host': 'localhost',
    'database': 'fdc'
}

num_dummy_data = 100

connection = mysql.connector.connect(**config)
cursor = connection.cursor()

for _ in range(num_dummy_data):
    data = generate_dummy_data_for_interlock_log()
    query = f"INSERT INTO interlock_log (interlock_log_id, equipment_id, interlock_id, state, start_time, end_time) VALUES ('{data[0]}', '{data[1]}', '{data[2]}', {data[3]}, '{data[4]}', '{data[5]}')"
    cursor.execute(query)

connection.commit()
cursor.close()
connection.close()

print(f"{num_dummy_data}개의 더미 데이터가 추가되었습니다.")
