import random
import string
from fdc.models import Param

def generate_dummy_data_param():
    while True:
        first_letter = ''.join(random.choices(string.ascii_uppercase, k=2))
        rest_letters = ''.join(random.choices(string.digits, k=6))
        equipment_id = first_letter + rest_letters
        if not Param.objects.filter(equipment_id=equipment_id).exists():
            break
    param_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    param_name = random.choice(['Param1', 'Param2', 'Param3'])
    param_type = random.choice(['A', 'B'])
    param_state = random.randint(0, 1)
    out_count = random.randint(0, 100)
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    created_at = ''
    updated_at = ''

    return (param_id, equipment_id, param_name, param_type, param_state, out_count, creator_name, created_at, modifier_name, updated_at)
