import string
import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_for_param_history():
    param_history_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    param_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    old_value = random.uniform(0, 100)
    new_value = random.uniform(0, 100)
    updated_at = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    updated_at_str = updated_at.strftime('%Y-%m-%d %H:%M:%S')

    return (param_history_id, param_id, equipment_id, old_value, new_value, updated_at_str)
