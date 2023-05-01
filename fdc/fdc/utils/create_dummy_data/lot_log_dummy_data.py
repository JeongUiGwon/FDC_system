import string
import random
from datetime import datetime, timedelta
from fdc.models import Equipment, Recipe

def generate_dummy_data_lot_log():
    equipment = random.choice(Equipment.objects.all())
    recipe = random.choice(Recipe.objects.all())
    lot_state = random.choice(['start', 'end'])

    return (equipment, recipe, lot_state)
