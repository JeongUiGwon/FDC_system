import random
import string
from fdc.models import Equipment
def generate_dummy_data_equipment():
    equipment_name = random.choice(['믹서', '코터', '프레스', '슬리터', '권취기', 'Taping', 'X-Ray', '세정기', 'Aging', '충방전기', 'IR/OCV 검사기'])
    equipment_state = random.choice(['RUN', 'IDLE', 'DOWN'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    return (equipment_name, equipment_state, creator_name, modifier_name)