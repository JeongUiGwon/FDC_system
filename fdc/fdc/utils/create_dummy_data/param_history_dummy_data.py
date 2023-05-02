import random
from fdc.utils.create_dummy_data.create_time import random_past_datetime
from fdc.models import Param

def generate_dummy_data_param_history():
    action = random.choice(['CREATE', 'READ', 'UPDATE', 'DELETE'])
    created_at = random_past_datetime()
    param = random.choice(Param.objects.all())
    param_name = param.param_name

    return (action,
            created_at,
            param,
            param_name)
