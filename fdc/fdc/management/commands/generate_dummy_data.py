import mysql.connector
import sys, os
from django.apps import apps
import django
import pprint
from pathlib import Path
from django.core.management.base import BaseCommand
from ...utils.create_dummy_data.equipment_dummy_data import *
from django.db import models

# app_directory = Path(__file__).resolve().parent.parent.parent
# sys.path.append(str(app_directory))
#
# os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'app.settings')
#
# django.setup()

class Command(BaseCommand):
    help = 'Generate dummy data for specified table'

    def add_arguments(self, parser):
        parser.add_argument('table_name', type=str, help='Name of the table to generate dummy data for')


    def handle(self, *args, **options):
        table_name = options['table_name']

        num_dummy_data = 10

        def find_model_class_by_table_name(table_name):
            for model in apps.get_models():
                if model._meta.db_table == table_name:
                    return model
            raise ValueError(f"Model for table '{table_name}' not found.")

        model_class = find_model_class_by_table_name(table_name)
        generator = globals().get(f"generate_dummy_data_{table_name}", None)
        if not generator:
            raise ValueError(f"Generator function for table '{table_name}' not found.")

        columns = [f.name for f in model_class._meta.fields if not f.primary_key and f.name != 'interlock_id' and
                   not (f.is_relation or isinstance(f, models.ManyToOneRel)) and
                   hasattr(f,'has_default') and not f.has_default()]

        for _ in range(num_dummy_data):
            data = generator()
            instance = model_class()

            for column, value in zip(columns, data):
                setattr(instance, column, value)

            instance.save()

        self.stdout.write(self.style.SUCCESS(f"{num_dummy_data}개의 더미 데이터가 추가되었습니다."))