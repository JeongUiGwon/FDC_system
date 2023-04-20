# Generated by Django 4.2 on 2023-04-19 05:09

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Equipment',
            fields=[
                ('equipment_id', models.CharField(max_length=100, primary_key=True, serialize=False)),
                ('equipment_name', models.CharField(max_length=100)),
                ('equipment_state', models.IntegerField(default=1)),
                ('creater_name', models.CharField(max_length=100)),
                ('created_at', models.DateTimeField()),
                ('modifier_name', models.CharField(max_length=100)),
                ('updated_at', models.DateTimeField()),
                ('interlock_id', models.CharField(max_length=100)),
            ],
            options={
                'db_table': 'equipment',
            },
        ),
        migrations.CreateModel(
            name='EquipmentState',
            fields=[
                ('lot_no', models.IntegerField(primary_key=True, serialize=False)),
                ('msg_name', models.CharField(max_length=100)),
                ('msg_version', models.CharField(max_length=20)),
                ('factory_id', models.IntegerField()),
                ('equipment_id', models.IntegerField()),
                ('created_at', models.DateTimeField()),
                ('mode', models.IntegerField(null=True)),
                ('status', models.IntegerField(null=True)),
            ],
            options={
                'db_table': 'equipment_state',
            },
        ),
        migrations.CreateModel(
            name='InterlockLog',
            fields=[
                ('lot_no', models.IntegerField(primary_key=True, serialize=False)),
                ('msg_name', models.CharField(max_length=100)),
                ('msg_version', models.CharField(max_length=20)),
                ('factory_id', models.IntegerField()),
                ('param_id', models.CharField(max_length=100)),
                ('recipe_id', models.CharField(max_length=100)),
                ('lot_id', models.IntegerField()),
                ('created_at', models.DateTimeField()),
                ('interlock_type', models.IntegerField()),
                ('out_count', models.IntegerField()),
                ('lower_limit', models.IntegerField(null=True)),
                ('upper_limit', models.IntegerField(null=True)),
                ('data_value', models.IntegerField(null=True)),
                ('cctv_video', models.CharField(max_length=100, null=True)),
            ],
            options={
                'db_table': 'interlock_log',
            },
        ),
        migrations.CreateModel(
            name='LotLog',
            fields=[
                ('data_id', models.IntegerField(primary_key=True, serialize=False)),
                ('name', models.CharField(max_length=100)),
                ('version', models.CharField(max_length=20)),
                ('factory_id', models.IntegerField()),
                ('equipment_id', models.IntegerField()),
                ('created_at', models.DateTimeField()),
                ('recipe_id', models.IntegerField()),
                ('lot_id', models.IntegerField()),
            ],
            options={
                'db_table': 'lot_log',
            },
        ),
        migrations.CreateModel(
            name='Param',
            fields=[
                ('param_id', models.CharField(max_length=100, primary_key=True, serialize=False)),
                ('param_name', models.CharField(max_length=100)),
                ('param_type', models.CharField(max_length=2)),
                ('param_state', models.IntegerField(default=1)),
                ('out_count', models.IntegerField()),
                ('creater_name', models.CharField(max_length=100)),
                ('created_at', models.DateTimeField()),
                ('modifier_name', models.CharField(max_length=100)),
                ('updated_at', models.DateTimeField()),
                ('equipment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.equipment')),
            ],
            options={
                'db_table': 'param',
            },
        ),
        migrations.CreateModel(
            name='ParamHistory',
            fields=[
                ('log_id', models.IntegerField(primary_key=True, serialize=False)),
                ('action', models.CharField(max_length=20)),
                ('created_at', models.DateTimeField()),
                ('param_id', models.DateTimeField()),
                ('old_value', models.CharField(max_length=100, null=True)),
                ('new_value', models.CharField(max_length=100, null=True)),
                ('column_name', models.CharField(max_length=20)),
            ],
            options={
                'db_table': 'param_history',
            },
        ),
        migrations.CreateModel(
            name='ParamLog',
            fields=[
                ('lot_no', models.IntegerField(primary_key=True, serialize=False)),
                ('msg_name', models.CharField(max_length=100)),
                ('msg_version', models.CharField(max_length=20)),
                ('factory_id', models.IntegerField()),
                ('equipment_id', models.IntegerField()),
                ('recipe_id', models.IntegerField()),
                ('created_at', models.DateTimeField()),
                ('data_list', models.CharField(max_length=200, null=True)),
                ('param_list', models.CharField(max_length=200, null=True)),
            ],
            options={
                'db_table': 'param_log',
            },
        ),
        migrations.CreateModel(
            name='RecipeHistory',
            fields=[
                ('log_id', models.IntegerField(primary_key=True, serialize=False)),
                ('action', models.CharField(max_length=20)),
                ('created_at', models.DateTimeField()),
                ('recipe_id', models.CharField(max_length=100)),
                ('old_value', models.CharField(max_length=100, null=True)),
                ('new_value', models.CharField(max_length=100, null=True)),
                ('column_name', models.CharField(max_length=20)),
            ],
            options={
                'db_table': 'recipe_history',
            },
        ),
        migrations.CreateModel(
            name='Recipe',
            fields=[
                ('recipe_id', models.CharField(max_length=100, primary_key=True, serialize=False)),
                ('recipe_name', models.CharField(max_length=100)),
                ('lsl', models.IntegerField(null=True)),
                ('usl', models.IntegerField(null=True)),
                ('lsl_action', models.CharField(max_length=100, null=True)),
                ('usl_action', models.CharField(max_length=100, null=True)),
                ('recipe_state', models.IntegerField(default=1)),
                ('creater_name', models.CharField(max_length=100)),
                ('created_at', models.DateTimeField()),
                ('modifier_name', models.CharField(max_length=100)),
                ('updated_at', models.DateTimeField()),
                ('equipment', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.equipment')),
                ('param', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='fdc.param')),
            ],
            options={
                'db_table': 'recipe',
            },
        ),
    ]
