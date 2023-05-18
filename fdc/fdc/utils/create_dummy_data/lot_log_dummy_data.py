import random
from ...models import Equipment, Recipe, Param
from ...utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past

def generate_dummy_data_lot_log():
    recipe = random.choice(Recipe.objects.all())
    equipment = Equipment.objects.get(pk=recipe.equipment_id)
    param = Param.objects.get(pk=recipe.param_id)
    start_time = random_past_datetime()
    end_time = random_future_datetime_from_past()

    created_at = random_past_datetime()

    # lot_state = random.choice(['start', 'end'])

    return (equipment,
            start_time,
            end_time,
            param,
            recipe,
            created_at)
