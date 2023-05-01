import string

import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_lot_log():
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
