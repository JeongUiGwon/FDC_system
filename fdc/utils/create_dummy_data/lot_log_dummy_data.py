import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_for_lot_log():
    lot_log_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    lot_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    recipe_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    status = random.choice(['RUN', 'IDLE', 'DOWN'])
    start_time = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    end_time = start_time + timedelta(hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    start_time_str = start_time.strftime('%Y-%m-%d %H:%M:%S')
    end_time_str = end_time.strftime('%Y-%m-%d %H:%M:%S')

    return (lot_log_id, lot_id, equipment_id, recipe_id, status, start_time_str, end_time_str)

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
    data = generate_dummy_data_for_lot_log()
    query = f"INSERT INTO lot_log (lot_log_id, lot_id, equipment_id, recipe_id, status, start_time, end_time) VALUES ('{data[0]}', '{data[1]}', '{data[2]}', '{data[3]}', '{data[4]}', '{data[5]}', '{data[6]}')"
    cursor.execute(query)

connection.commit()
cursor.close()
connection.close()

print(f"{num_dummy_data}개의 더미 데이터가 추가되었습니다.")

