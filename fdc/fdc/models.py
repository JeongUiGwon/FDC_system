from django.db import models
from datetime import datetime, timedelta
import random, string
from django.apps import apps
from psqlextra.models import PostgresPartitionedModel
from psqlextra.types import PostgresPartitioningMethod

is_manage = True

def random_past_datetime():
    return datetime.now() - timedelta(days=random.randint(0, 365*2),
                                      hours=random.randint(0, 23),
                                      minutes=random.randint(0, 59),
                                      seconds=random.randint(0, 59))

def random_future_datetime_from_past():
    past_time = random_past_datetime()
    return past_time + timedelta(days=random.randint(0, 365*2),
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
        if not isinstance(field, models.ManyToOneRel) and field.primary_key:
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
    equipment_id = models.CharField(max_length=50, primary_key=True)
    equipment_name = models.CharField(max_length=50)
    equipment_use = models.CharField(max_length=10)
    equipment_state = models.CharField(max_length=10, null=True)
    equipment_mode = models.CharField(max_length=10, null=True)
    creator_name = models.CharField(max_length=50)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=50, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)
    interlock_id = models.CharField(max_length=50)

    def save(self, *args, **kwargs):
        if not self.equipment_id:
            self.equipment_id = random_id_generate('equipment', 8)
        if not self.interlock_id:
            self.interlock_id = self.equipment_id
        super().save(*args, **kwargs)
    class Meta:
        db_table = 'equipment'

class Param(models.Model):
    param_id = models.CharField(max_length=50, primary_key=True)
    equipment = models.ForeignKey(Equipment, on_delete=models.PROTECT)
    param_name = models.CharField(max_length=50)
    param_level = models.CharField(max_length=2)
    param_state = models.CharField(max_length=10)
    creator_name = models.CharField(max_length=50)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=50, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)

    def save(self, *args, **kwargs):
        if not self.param_id:
            self.param_id = random_id_generate('param', 15)
        super().save(*args, **kwargs)
    class Meta:
        db_table = 'param'

class Recipe(models.Model):
    recipe_id = models.CharField(max_length=50, primary_key=True)
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    param = models.ForeignKey(Param, on_delete=models.CASCADE)
    recipe_name = models.CharField(max_length=50)
    lsl = models.FloatField(null=True)
    usl = models.FloatField(null=True)
    lsl_interlock_action = models.CharField(max_length=50, null=True)
    usl_interlock_action = models.CharField(max_length=50, null=True)
    recipe_use = models.CharField(max_length=10)
    creator_name = models.CharField(max_length=50)
    created_at = models.DateTimeField(default=random_past_datetime)
    modifier_name = models.CharField(max_length=50, null=True)
    updated_at = models.DateTimeField(default=random_future_datetime_from_past, null=True)

    def save(self, *args, **kwargs):
        if not self.recipe_id:
            self.recipe_id = random_id_generate('recipe', 20)
        super().save(*args, **kwargs)
    class Meta:
        db_table = 'recipe'

class LotLog(PostgresPartitionedModel):
    lot_id = models.CharField(max_length=15, primary_key=True)
    factory_id = models.CharField(max_length=10, default='KOR')
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    start_time = models.DateTimeField(default=random_past_datetime)
    end_time = models.DateTimeField(default=random_future_datetime_from_past)
    recipe_id = models.ForeignKey(Recipe, on_delete=models.CASCADE)
    lot_state = models.CharField(max_length=10, null=True)
    created_at = models.DateTimeField(default=random_past_datetime)

    def save(self, *args, **kwargs):
        if not self.lot_id:
            self.lot_id = random_id_generate('lot_log', 12)
        super().save(*args, **kwargs)
    class Meta:
        db_table = 'lot_log'
        managed = True

    class PartitioningMeta:
        method = PostgresPartitioningMethod.RANGE
        key = ["created_at"]

    # class PartitioningMeta:
    #     key = ('created_at',)
class EquipmentState(models.Model):
    id = models.AutoField(primary_key=True)
    factory_id = models.CharField(max_length=10, default='KOR')
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    created_at = models.DateTimeField(default=random_past_datetime)
    mode = models.CharField(max_length=10, null=True)
    status = models.CharField(max_length=10, null=True)

    class Meta:
        db_table = 'equipment_state'

class ParamLog(models.Model):
    log_id = models.AutoField(primary_key=True)
    factory_id = models.CharField(max_length=10, default='KOR')
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    param = models.ForeignKey(Param, on_delete=models.CASCADE)
    recipe = models.ForeignKey(Recipe, on_delete=models.CASCADE)
    created_at = models.DateTimeField(default=random_past_datetime)
    # data_list = models.CharField(max_length=200, null=True)
    param_value = models.FloatField(null=True)


    class Meta:
        db_table = 'param_log'
        managed = False

    class PartitioningMeta:
        method = PostgresPartitioningMethod.RANGE
        key = ["created_at"]
        #
        # partition_key = "created_at"
        # partition_type = PostgresPartitionedModel.RANGE
        # partition_subtype = PostgresPartitionedModel.YEAR

class InterlockLog(models.Model):
    # class PartitioningMeta:
    #     method = PostgresPartitionedModel.RANGE

    log_id = models.AutoField(primary_key=True)
    factory_id = models.CharField(max_length=10, default='KOR')
    equipment = models.ForeignKey(Equipment, on_delete=models.CASCADE)
    equipment_name = models.CharField(max_length=50, null=True)
    cause_equip_id = models.CharField(max_length=50, null=True)
    cause_equip_name = models.CharField(max_length=50)
    param = models.ForeignKey(Param, on_delete=models.CASCADE)
    recipe = models.ForeignKey(Recipe, on_delete=models.CASCADE)
    lot = models.ForeignKey(LotLog, on_delete=models.CASCADE)
    created_at = models.DateTimeField(default=random_past_datetime)
    interlock_type = models.CharField(max_length=15)
    out_count = models.IntegerField()
    lower_limit = models.FloatField(null=True)
    upper_limit = models.FloatField(null=True)
    data_value = models.IntegerField(null=True)
    cctv_video_url = models.CharField(max_length=50, null=True)

    def save(self, *args, **kwargs):
        if self.equipment:
            self.equipment_name = self.equipment.equipment_name
            self.cause_equip_id = self.equipment
            self.cause_equip_name = self.equipment_name

        super(InterlockLog, self).save(*args, **kwargs)
    class Meta:
        db_table = 'interlock_log'
        managed = False

class ParamHistory(models.Model): # TODO GET 할 때 param_name join해서 보여주기
    log_id = models.AutoField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField(default=random_past_datetime)
    param = models.ForeignKey(Param, on_delete=models.CASCADE)
    param_name = models.CharField(max_length=50)
    old_value = models.JSONField(null=True)
    new_value = models.JSONField(null=True)

    def save(self, *args, **kwargs):
        self.param_name = self.param.param_name
        super().save(*args, **kwargs)
    class Meta:
        db_table = 'param_history'
        managed = is_manage

class RecipeHistory(models.Model):
    log_id = models.AutoField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField(default=random_past_datetime)
    recipe = models.ForeignKey(Recipe, on_delete=models.CASCADE)
    old_value = models.JSONField(null=True)
    new_value = models.JSONField(null=True)

    class Meta:
        db_table = 'recipe_history'
        managed = is_manage