import random
from fdc.models import Equipment

def generate_dummy_data_param():
    param_name = random.choice(['수평 진동', '수직 진동', '탱크 온도'])
    param_level = random.choice(['S', 'A', 'B'])
    param_state = random.choice(['RUN', 'DOWN'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    equipment = random.choice(Equipment.objects.all())

    return (equipment, param_name, param_level, param_state, creator_name, modifier_name)
