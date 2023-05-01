import random
from datetime import datetime, timedelta
from fdc.models import Equipment

def generate_dummy_data_equipment_state():
    equipment = random.choice(Equipment.objects.all())
    mode = random.choice(['MANUAL', 'AUTO'])
    status = random.choice(['PROCESSING', 'IDLE', 'PAUSE'])

    return (equipment, mode, status)
