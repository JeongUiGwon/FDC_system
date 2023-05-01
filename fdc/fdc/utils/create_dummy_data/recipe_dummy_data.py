import random
from fdc.models import Equipment, Param


def generate_dummy_data_recipe():
    recipe_name = random.choice(['Recipe1', 'Recipe2', 'Recipe3'])
    lsl = random.uniform(2, 3)
    usl = random.uniform(3, 4)
    lsl_interlock_action = random.choice(['MAIL', 'WARNING', 'INTERLOCK'])
    usl_interlock_action = random.choice(['MAIL', 'WARNING', 'INTERLOCK'])
    recipe_use = random.choice(['사용', '미사용'])
    creator_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])
    modifier_name = random.choice(['최명서', '정의권', '임상빈', '조성환', '채민기', '김지선'])

    equipment = random.choice(Equipment.objects.all())
    param = random.choice(Param.objects.all())

    return (equipment, param, recipe_name, lsl, usl, lsl_interlock_action, usl_interlock_action, recipe_use, creator_name, modifier_name)
