# Generated by Django 4.2 on 2023-04-18 08:14

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('fdc', '0002_rename_interlock_interlockinfo_and_more'),
    ]

    operations = [
        migrations.RenameModel(
            old_name='LogInterlock',
            new_name='InterlockLog',
        ),
    ]
