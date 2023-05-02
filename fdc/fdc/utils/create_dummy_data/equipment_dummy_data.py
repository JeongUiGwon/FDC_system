import random
from fdc.utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past


def generate_dummy_data_equipment():
    equipment_name = random.choice(['믹서', '코터', '프레스', '슬리터', '권취기', 'Taping', 'X-Ray', '세정기', 'Aging', '충방전기', 'IR/OCV 검사기'])
    equipment_use = random.choice(['사용', '미사용'])
    equipment_state = random.choice(['PROCESSING', 'IDLE', 'PAUSE'])
    equipment_mode = random.choice(['AUTO', 'MANUAL'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    created_at = random_past_datetime()
    updated_at = random_future_datetime_from_past()

    return (equipment_name,
            equipment_use,
            equipment_state,
            equipment_mode,
            creator_name,
            created_at,
            modifier_name,
            updated_at)