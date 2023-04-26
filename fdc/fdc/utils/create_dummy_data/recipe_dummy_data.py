import string

import mysql.connector
import random
from datetime import datetime, timedelta

def generate_dummy_data_recipe():
    recipe_id = ''.join(random.choices(string.ascii_uppercase + string.digits, k=8))
    equipment_id = 'A' + ''.join(random.choices(string.digits, k=7))
    recipe_name = random.choice(['Recipe1', 'Recipe2', 'Recipe3'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    return (recipe_id, recipe_name, equipment_id, creator_name, created_at_str, modifier_name, updated_at_str)
