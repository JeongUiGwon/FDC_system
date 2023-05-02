import random
from fdc.utils.create_dummy_data.create_time import random_past_datetime
from fdc.models import Recipe

def generate_dummy_data_recipe_history():
    action = random.choice(['CREATE', 'READ', 'UPDATE', 'DELETE'])
    created_at = random_past_datetime()
    recipe = random.choice(Recipe.objects.all())

    return (action,
            created_at,
            recipe)
