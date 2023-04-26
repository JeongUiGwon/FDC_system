import string

import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_equipment_state():
    first_letter = random.choice(['A', 'B', 'C'])
    rest_letters = random.choice(['1000000', '2000000', '3000000'])
    equipment_id = first_letter + rest_letters
    state = random.choice(['RUN', 'IDLE', 'DOWN'])
    start_time = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    end_time = start_time + timedelta(hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    start_time_str = start_time.strftime('%Y-%m-%d %H:%M:%S')
    end_time_str = end_time.strftime('%Y-%m-%d %H:%M:%S')

    return (equipment_id, state, start_time_str, end_time_str)
