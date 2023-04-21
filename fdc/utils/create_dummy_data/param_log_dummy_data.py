import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_for_param_log():
    param_log_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    param_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    lot_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    value = random.uniform(0, 100)
    created_at = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    created_at_str = created_at.strftime('%Y-%m-%d %H:%M:%S')

    return (param_log_id, param_id, lot_id, equipment_id, value, created_at_str)

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
    data = generate_dummy_data_for_param_log()
    query = f"INSERT INTO param_log (param_log_id, param

