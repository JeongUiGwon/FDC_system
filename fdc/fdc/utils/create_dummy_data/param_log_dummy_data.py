import string
import random
from datetime import datetime, timedelta
from fdc.models import Equipment, Param, Recipe

def generate_dummy_data_param_log():
    equipment = random.choice(Equipment.objects.all())
    param = random.choice(Param.objects.all())
    recipe = random.choice(Recipe.objects.all())
    value = random.uniform(2.5, 3.5)

    return equipment, param, recipe, value
