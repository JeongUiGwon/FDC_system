# Generated by Django 4.2 on 2023-04-18 08:17

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('fdc', '0003_rename_loginterlock_interlocklog'),
    ]

    operations = [
        migrations.RenameModel(
            old_name='InterlockLog',
            new_name='LogInterlock',
        ),
        migrations.RenameModel(
            old_name='paramLog',
            new_name='LogParam',
        ),
        migrations.RenameModel(
            old_name='recipeLog',
            new_name='LogRecipe',
        ),
    ]
