import string

import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_param_log():
    param_log_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    param_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    lot_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    first_letter = random.choice(['A', 'B', 'C'])
    rest_letters = random.choice(['1000000', '2000000', '3000000'])
    equipment_id = first_letter + rest_letters
    value = random.uniform(0, 100)
    created_at = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    created_at_str = created_at.strftime('%Y-%m-%d %H:%M:%S')

    return (param_log_id, param_id, lot_id, equipment_id, value, created_at_str)
