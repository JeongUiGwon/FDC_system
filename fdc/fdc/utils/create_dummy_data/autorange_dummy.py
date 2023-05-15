import random
from ...models import Equipment, Param, Recipe, LotLog
from ...utils.create_dummy_data.create_time import random_past_datetime
from datetime import datetime


def generate_dummy_data_auto_range():
    param_id = Param.objects.get(pk='48EKB0UA1VT54ZS')
    min_range = 5
    max_range = 5
    type = 'sigma'
    # created_at = datetime.now()
    is_active = True

    return (param_id, min_range, max_range, type, is_active)
