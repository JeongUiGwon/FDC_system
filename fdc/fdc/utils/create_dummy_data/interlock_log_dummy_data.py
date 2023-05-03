import random
from ...models import Equipment, Param, Recipe, LotLog
from ...utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past


def generate_dummy_data_interlock_log():
    equipment = random.choice(Equipment.objects.all())
    param = random.choice(Param.objects.all())
    recipe = random.choice(Recipe.objects.all())
    lot = random.choice(LotLog.objects.all())
    created_at = random_past_datetime()
    interlock_type = random.choice(['S', 'A', 'B'])
    out_count = random.choice(['0', '1', '2', '3'])
    lower_limit = recipe.lsl
    upper_limit = recipe.usl
    data_value = random.uniform(lower_limit, upper_limit)

    return (equipment,
            param,
            recipe,
            lot,
            created_at,
            interlock_type,
            out_count,
            lower_limit,
            upper_limit,
            data_value)
