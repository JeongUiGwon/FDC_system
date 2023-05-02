import random
from fdc.models import Equipment, Recipe
from fdc.utils.create_dummy_data.create_time import random_past_datetime, random_future_datetime_from_past

def generate_dummy_data_lot_log():
    equipment = random.choice(Equipment.objects.all())
    start_time = random_past_datetime()
    end_time = random_future_datetime_from_past()
    recipe = random.choice(Recipe.objects.all())
    created_at = random_past_datetime()

    # lot_state = random.choice(['start', 'end'])

    return (equipment,
            start_time,
            end_time,
            recipe,
            created_at)
