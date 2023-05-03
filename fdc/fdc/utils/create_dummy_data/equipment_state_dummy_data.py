import random
from ...models import Equipment
from ...utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past

def generate_dummy_data_equipment_state():
    equipment = random.choice(Equipment.objects.all())
    mode = random.choice(['MANUAL', 'AUTO'])
    status = random.choice(['PROCESSING', 'IDLE', 'PAUSE'])

    created_at = random_past_datetime()

    return (equipment,
            created_at,
            mode,
            status)
