from django.db import models

class Equipment(models.Model):
    equipment_id = models.CharField(max_length=100, primary_key=True)
    equipment_name = models.CharField(max_length=100)
    equipment_state = models.CharField(max_length=10)
    creater_name = models.CharField(max_length=100)
    created_at = models.DateTimeField()
    modifier_name = models.CharField(max_length=100)
    updated_at = models.DateTimeField()
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
    creater_name = models.CharField(max_length=100)
    created_at = models.DateTimeField()
    modifier_name = models.CharField(max_length=100)
    updated_at = models.DateTimeField()

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
    creater_name = models.CharField(max_length=100)
    created_at = models.DateTimeField()
    modifier_name = models.CharField(max_length=100)
    updated_at = models.DateTimeField()

    class Meta:
        db_table = 'recipe'

class LotLog(models.Model):
    data_id = models.IntegerField(primary_key=True)
    name = models.CharField(max_length=100)
    version = models.CharField(max_length=20)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    created_at = models.DateTimeField()
    recipe_id = models.IntegerField()
    lot_id = models.IntegerField()

    class Meta:
        db_table = 'lot_log'


class EquipmentState(models.Model):
    lot_no = models.IntegerField(primary_key=True)
    msg_name = models.CharField(max_length=100)
    msg_version = models.CharField(max_length=20)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    created_at = models.DateTimeField()
    mode = models.IntegerField(null=True)
    status = models.IntegerField(null=True)

    class Meta:
        db_table = 'equipment_state'

class ParamLog(models.Model):
    lot_no = models.IntegerField(primary_key=True)
    msg_name = models.CharField(max_length=100)
    msg_version = models.CharField(max_length=20)
    factory_id = models.IntegerField()
    equipment_id = models.IntegerField()
    recipe_id = models.IntegerField()
    created_at = models.DateTimeField()
    data_list = models.CharField(max_length=200, null=True)
    param_list = models.CharField(max_length=200, null=True)

    class Meta:
        db_table = 'param_log'

class InterlockLog(models.Model):
    lot_no = models.IntegerField(primary_key=True)
    msg_name = models.CharField(max_length=100)
    msg_version = models.CharField(max_length=20)
    factory_id = models.IntegerField()
    param_id = models.CharField(max_length=100)
    recipe_id = models.CharField(max_length=100)
    lot_id = models.IntegerField()
    created_at = models.DateTimeField()
    interlock_type = models.IntegerField()
    out_count = models.IntegerField()
    lower_limit = models.IntegerField(null=True)
    upper_limit = models.IntegerField(null=True)
    data_value = models.IntegerField(null=True)
    cctv_video = models.CharField(max_length=100, null=True)

    class Meta:
        db_table = 'interlock_log'

class ParamHistory(models.Model):
    log_id = models.IntegerField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField()
    param_id = models.DateTimeField()
    old_value = models.CharField(max_length=100, null=True)
    new_value = models.CharField(max_length=100, null=True)
    column_name = models.CharField(max_length=20)

    class Meta:
        db_table = 'param_history'

class RecipeHistory(models.Model):
    log_id = models.IntegerField(primary_key=True)
    action = models.CharField(max_length=20)
    created_at = models.DateTimeField()
    recipe_id = models.CharField(max_length=100)
    old_value = models.CharField(max_length=100, null=True)
    new_value = models.CharField(max_length=100, null=True)
    column_name = models.CharField(max_length=20)

    class Meta:
        db_table = 'recipe_history'
