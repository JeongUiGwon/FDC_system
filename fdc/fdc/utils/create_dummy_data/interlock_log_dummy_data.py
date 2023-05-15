import random
from ...models import Equipment, Param, Recipe, LotLog
from ...utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past
from datetime import datetime


def generate_dummy_data_interlock_log():
    # lot = random.choice(LotLog.objects.all())
    recipe = random.choice(Recipe.objects.all())
    equipment = Equipment.objects.get(pk=recipe.equipment_id)
    param = Param.objects.get(pk=recipe.param_id)
    created_at = datetime.now()
    interlock_type = recipe.usl_interlock_action
    out_count = random.choice(['0', '1', '2', '3'])
    lower_limit = recipe.lsl + 1
    upper_limit = recipe.usl - 1
    data_value = random.uniform(lower_limit, upper_limit)

    return (equipment,
            param,
            recipe,
            created_at,
            interlock_type,
            out_count,
            lower_limit,
            upper_limit,
            data_value)
