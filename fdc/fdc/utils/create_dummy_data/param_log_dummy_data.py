import random
from fdc.models import Equipment, Param, Recipe
from fdc.utils.create_dummy_data.create_time import random_past_datetime

def generate_dummy_data_param_log():
    equipment = random.choice(Equipment.objects.all())
    param = random.choice(Param.objects.all())
    recipe = random.choice(Recipe.objects.all())
    value = round(random.uniform(recipe.lsl, recipe.usl), 6)

    create_at = random_past_datetime()

    return (equipment,
            param,
            recipe,
            create_at,
            value)
