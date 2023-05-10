import random
from ...models import Equipment, Param, Recipe
from ...utils.create_dummy_data.create_time import random_past_datetime

def generate_dummy_data_param_log():
    recipe = random.choice(Recipe.objects.all())
    param = Param.objects.get(pk=recipe.param_id.strip())
    equipment = Equipment.objects.get(pk=recipe.equipment_id.strip())

    value = round(random.uniform(recipe.lsl, recipe.usl), 6)

    create_at = random_past_datetime()

    return (equipment,
            param,
            recipe,
            create_at,
            value)
