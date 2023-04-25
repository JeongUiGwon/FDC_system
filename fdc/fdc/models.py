from django.db import models
from datetime import datetime, timedelta
import random, string
from django.apps import apps
from functools import partial

is_manage = True

def random_past_datetime():
    return datetime.now() - timedelta(days=random.randint(0, 365),
                                      hours=random.randint(0, 23),
                                      minutes=random.randint(0, 59),
                                      seconds=random.randint(0, 59))

def random_future_datetime_from_past():
    past_time = random_past_datetime()
    return past_time + timedelta(days=random.randint(0, 365),
                                 hours=random.randint(0, 23),
                                 minutes=random.randint(0, 59),
                                 seconds=random.randint(0, 59))


def generate_id(length):
    characters = string.ascii_uppercase + string.digits
    id = ''.join(random.choice(characters) for i in range(length))

    return id

def get_model(table_name):
    for model in apps.get_models():
        if model._meta.db_table == table_name:
            return model

    raise ValueError(f"Model for table '{table_name}' not found.")

def get_pk(model_class):
    for field in model_class._meta.get_fields():
        if field.primary_key:
            return field.name

    raise ValueError(f"pk of '{model_class}' not found.")

def random_id_generate(table_name, length):
    model_class = get_model(table_name)
    pk = get_pk(model_class)

    id = generate_id(length)
    while model_class.objects.filter(**{pk: id}).exists():
        id = generate_id(length)

    return id

class Equipment(models.Model):
    equipment_id = models.CharField(max_length=100, primary_key=True, default=partial)
    equipment_name = models.CharField(max_length=100)
    equipment_state = models.CharField(max_length=10)
    creator_name = models.CharField(max_length=100)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=100, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)

    interlock_id = models.CharField(max_length=100)

    class Meta:
        db_table = 'equipment'

class Param(models.Model):
    param_id = models.CharField(max_length=100, primary_key=True)
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    param_name = models.CharField(max_length=100)
    param_type = models.CharField(max_length=2)
    param_state = models.IntegerField(default=1)
    out_count = models.IntegerField()
    creator_name = models.CharField(max_length=100)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=100, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)


    class Meta:
        db_table = 'param'

class Recipe(models.Model):
    recipe_id = models.CharField(max_length=100, primary_key=True)
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    param = models.ForeignKey(Param, on_delete=models.CASCADE)
    recipe_name = models.CharField(max_length=100)
    lsl = models.IntegerField(null=True)
    usl = models.IntegerField(null=True)
    lsl_action = models.CharField(max_length=100, null=True)
    usl_action = models.CharField(max_length=100, null=True)
    recipe_state = models.IntegerField(default=1)
    creator_name = models.CharField(max_length=100)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=100, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)


    class Meta:
        db_table = 'recipe'

class LotLog(models.Model):
    log_id = models.AutoField(primary_key=True)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    created_at = models.DateTimeField(default=random_past_datetime)
    recipe_id = models.IntegerField()
    lot_id = models.IntegerField()

    class Meta:
        db_table = 'lot_log'
        managed = is_manage

class EquipmentState(models.Model):
    id = models.IntegerField(primary_key=True)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    created_at = models.DateTimeField(default=random_past_datetime)
    mode = models.IntegerField(null=True)
    status = models.IntegerField(null=True)

    class Meta:
        db_table = 'equipment_state'


class ParamLog(models.Model):
    log_id = models.AutoField(primary_key=True)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    recipe_id = models.IntegerField()
    created_at = models.DateTimeField(default=random_past_datetime)
    data_list = models.CharField(max_length=200, null=True)
    param_list = models.CharField(max_length=200, null=True)

    class Meta:
        db_table = 'param_log'
        managed = is_manage
class InterlockLog(models.Model):
    log_id = models.AutoField(primary_key=True)
    factory_id = models.CharField(max_length=20)
    equipment_id = models.CharField(max_length=100, default='')
    equipment_name = models.CharField(max_length=100, default='')
    cause_equip_id = models.CharField(max_length=100, default='')
    cause_equip_name = models.CharField(max_length=100, default='')
    param_id = models.CharField(max_length=100)
    recipe_id = models.CharField(max_length=100)
    lot_id = models.IntegerField()
    created_at = models.DateTimeField(default=random_past_datetime)
    interlock_type = models.IntegerField()
    out_count = models.IntegerField()
    lower_limit = models.IntegerField(null=True)
    upper_limit = models.IntegerField(null=True)
    data_value = models.IntegerField(null=True)
    cctv_video_url = models.CharField(max_length=100, null=True)

    class Meta:
        db_table = 'interlock_log'
        managed = is_manage

class ParamHistory(models.Model):
    log_id = models.AutoField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField(default=random_past_datetime)
    param_id = models.DateTimeField()
    old_value = models.CharField(max_length=100, null=True)
    new_value = models.CharField(max_length=100, null=True)
    column_name = models.CharField(max_length=20)

    class Meta:
        db_table = 'param_history'
        managed = is_manage

class RecipeHistory(models.Model):
    log_id = models.AutoField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField(default=random_past_datetime)
    recipe_id = models.CharField(max_length=100)
    old_value = models.CharField(max_length=100, null=True)
    new_value = models.CharField(max_length=100, null=True)
    column_name = models.CharField(max_length=20)

    class Meta:
        db_table = 'recipe_history'
        managed = is_manage