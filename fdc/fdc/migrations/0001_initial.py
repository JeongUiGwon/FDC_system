# Generated by Django 4.2 on 2023-05-03 13:13

from datetime import datetime
from django.db import migrations, models
import django.db.models.deletion
import fdc.models

class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='InterlockLog',
            fields=[
                ('log_id', models.AutoField(primary_key=True, serialize=False)),
                ('factory_id', models.CharField(default='KOR', max_length=10)),
                ('equipment_name', models.CharField(max_length=50, null=True)),
                ('cause_equip_id', models.CharField(max_length=50, null=True)),
                ('cause_equip_name', models.CharField(max_length=50, null=True)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('interlock_type', models.CharField(max_length=15)),
                ('out_count', models.IntegerField()),
                ('lower_limit', models.FloatField()),
                ('upper_limit', models.FloatField()),
                ('data_value', models.IntegerField()),
                ('cctv_video_url', models.CharField(max_length=50, null=True)),
            ],
            options={
                'db_table': 'interlock_log',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='LotLog',
            fields=[
                ('lot_id', models.CharField(max_length=15, primary_key=True, serialize=False)),
                ('factory_id', models.CharField(default='KOR', max_length=10)),
                ('start_time', models.DateTimeField(default=datetime.now)),
                ('end_time', models.DateTimeField(default=fdc.models.random_future_datetime_from_past)),
                ('lot_state', models.CharField(max_length=10, null=True)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
            ],
            options={
                'db_table': 'lot_log',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='ParamLog',
            fields=[
                ('log_id', models.AutoField(primary_key=True, serialize=False)),
                ('factory_id', models.CharField(default='KOR', max_length=10)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('param_value', models.FloatField()),
            ],
            options={
                'db_table': 'param_log',
                'managed': False,
            },
        ),
        migrations.CreateModel(
            name='Equipment',
            fields=[
                ('equipment_id', models.CharField(max_length=50, primary_key=True, serialize=False)),
                ('equipment_name', models.CharField(max_length=50)),
                ('equipment_use', models.CharField(max_length=10)),
                ('equipment_state', models.CharField(max_length=10)),
                ('equipment_mode', models.CharField(max_length=10)),
                ('creator_name', models.CharField(max_length=50)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('modifier_name', models.CharField(max_length=50, null=True)),
                ('updated_at', models.DateTimeField(null=True)),
                ('interlock_id', models.CharField(max_length=50)),
            ],
            options={
                'db_table': 'equipment',
            },
        ),
        migrations.CreateModel(
            name='Param',
            fields=[
                ('param_id', models.CharField(max_length=50, primary_key=True, serialize=False)),
                ('param_name', models.CharField(max_length=50)),
                ('param_level', models.CharField(max_length=2)),
                ('param_state', models.CharField(max_length=10)),
                ('creator_name', models.CharField(max_length=50)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('modifier_name', models.CharField(max_length=50, null=True)),
                ('updated_at', models.DateTimeField(null=True)),
                ('equipment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.equipment')),
            ],
            options={
                'db_table': 'param',
            },
        ),
        migrations.CreateModel(
            name='Recipe',
            fields=[
                ('recipe_id', models.CharField(max_length=50, primary_key=True, serialize=False)),
                ('recipe_name', models.CharField(max_length=50)),
                ('lsl', models.FloatField()),
                ('usl', models.FloatField()),
                ('lsl_interlock_action', models.CharField(max_length=50)),
                ('usl_interlock_action', models.CharField(max_length=50)),
                ('recipe_use', models.CharField(max_length=10)),
                ('creator_name', models.CharField(max_length=50)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('modifier_name', models.CharField(max_length=50, null=True)),
                ('updated_at', models.DateTimeField(null=True)),
                ('equipment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.equipment')),
                ('param', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.param')),
            ],
            options={
                'db_table': 'recipe',
            },
        ),
        migrations.CreateModel(
            name='RecipeHistory',
            fields=[
                ('log_id', models.AutoField(primary_key=True, serialize=False)),
                ('action', models.CharField(max_length=20)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('recipe_name', models.CharField(max_length=20)),
                ('old_value', models.JSONField(null=True)),
                ('new_value', models.JSONField(null=True)),
                ('recipe', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.recipe')),
            ],
            options={
                'db_table': 'recipe_history',
                'managed': True,
            },
        ),
        migrations.CreateModel(
            name='ParamHistory',
            fields=[
                ('log_id', models.AutoField(primary_key=True, serialize=False)),
                ('action', models.CharField(max_length=20)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('param_name', models.CharField(max_length=50)),
                ('old_value', models.JSONField(null=True)),
                ('new_value', models.JSONField(null=True)),
                ('param', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.param')),
            ],
            options={
                'db_table': 'param_history',
                'managed': True,
            },
        ),
        migrations.CreateModel(
            name='EquipmentState',
            fields=[
                ('id', models.AutoField(primary_key=True, serialize=False)),
                ('factory_id', models.CharField(default='KOR', max_length=10)),
                ('created_at', models.DateTimeField(default=fdc.models.random_past_datetime)),
                ('mode', models.CharField(max_length=10, null=True)),
                ('status', models.CharField(max_length=10, null=True)),
                ('equipment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.equipment')),
            ],
            options={
                'db_table': 'equipment_state',
            },
        ),
    ]
