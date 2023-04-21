import mysql.connector
import random
import string
from datetime import datetime, timedelta

def generate_dummy_data():
    first_letter = random.choice(['A', 'B', 'C'])
    rest_letters = ''.join(random.choices(string.digits, k=7))
    equipment_id = first_letter + rest_letters
    equipment_name = random.choice(['믹서', '코터', '프레스', '슬리터', '권취기', 'Taping', 'X-Ray', '세정기', 'Aging', '충방전기', 'IR/OCV 검사기'])
    equipment_state = random.choice(['Y', 'N'])
    creater_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    created_at = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    updated_at = created_at + timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    interlock_id = equipment_id

    created_at_str = created_at.strftime('%Y-%m-%d %H:%M:%S')
    updated_at_str = updated_at.strftime('%Y-%m-%d %H:%M:%S')

    return (equipment_id, equipment_name, equipment_state, creater_name, created_at_str, modifier_name, updated_at_str, interlock_id)

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
    data = generate_dummy_data()
    query = f"INSERT INTO equipment (equipment_id, equipment_name, equipment_state, creater_name, created_at, modifier_name, updated_at, interlock_id) VALUES ('{data[0]}', '{data[1]}', '{data[2]}', '{data[3]}', '{data[4]}', '{data[5]}', '{data[6]}', '{data[7]}')"
    cursor.execute(query)

connection.commit()

cursor.close()
connection.close()

print(f"{num_dummy_data}개의 더미 데이터가 추가되었습니다.")