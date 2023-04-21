import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_for_recipe():
    recipe_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    recipe_name = random.choice(['Recipe1', 'Recipe2', 'Recipe3'])
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    creater_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    created_at = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    updated_at = created_at + timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))

    created_at_str = created_at.strftime('%Y-%m-%d %H:%M:%S')
    updated_at_str = updated_at.strftime('%Y-%m-%d %H:%M:%S')

    return (recipe_id, recipe_name, equipment_id, creater_name, created_at_str, modifier_name, updated_at_str)

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
    data = generate_dummy_data_for_recipe()
    query = f"INSERT INTO recipe (recipe_id, recipe_name, equipment_id, creater_name, created_at, modifier_name, updated_at) VALUES ('{data[0]}', '{data[1]}', '{data[2]}', '{data[3]}', '{data[4]}', '{data[5]}', '{data[6]}')"
    cursor.execute(query)

connection.commit()
cursor.close()
connection.close()

print(f"{num_dummy_data}개의 더미 데이터가 추가되었습니다.")
