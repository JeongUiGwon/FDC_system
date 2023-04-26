import random, string
from datetime import datetime, timedelta


def generate_dummy_data_interlock_log(self):
    equipment_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    state = random.choice(['RUN', 'IDLE', 'DOWN'])
    start_time = datetime.now() - timedelta(days=random.randint(0, 365), hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    end_time = start_time + timedelta(hours=random.randint(0, 23), minutes=random.randint(0, 59), seconds=random.randint(0, 59))
    start_time_str = start_time.strftime('%Y-%m-%d %H:%M:%S')
    end_time_str = end_time.strftime('%Y-%m-%d %H:%M:%S')

    return (equipment_id, state, start_time_str, end_time_str)
