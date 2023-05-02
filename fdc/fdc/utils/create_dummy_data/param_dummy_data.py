import random
from fdc.models import Equipment
from fdc.utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past

def generate_dummy_data_param():
    param_name = random.choice(['수평 진동', '수직 진동', '탱크 온도'])
    param_level = random.choice(['S', 'A', 'B'])
    param_state = random.choice(['RUN', 'DOWN'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    equipment = random.choice(Equipment.objects.all())

    created_at = random_past_datetime()
    updated_at = random_future_datetime_from_past()

    return (equipment,
            param_name,
            param_level,
            param_state,
            creator_name,
            created_at,
            modifier_name,
            updated_at)
