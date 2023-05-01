import os, sys
import django
from django.db import connection
from datetime import date

sys.path.insert(0, '/home/ubuntu/fdc')
os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'app.settings')
django.setup()

from fdc.models import LotLog, ParamLog, InterlockLog

def create_yearly_partitions(model_class, start_year, end_year):
    table_name = model_class._meta.db_table
    key = model_class.partition_key

    with connection.cursor() as cursor:
        for year in range(start_year, end_year+1):
            partition_name = f"{table_name}_{year}"
            start_date = date(year, 1, 1)
            end_date = date(year+1, 1, 1)
            query = f"""
                CREATE TABLE {partition_name} PARTITION OF {table_name}
                FOR VALUES FROM ('{start_date}') TO ('{end_date}');
            """
            cursor.execute(query)

if __name__ == "__main__":
    create_yearly_partitions(LotLog, 2022, 2024)
    create_yearly_partitions(ParamLog, 2022, 2024)
    create_yearly_partitions(InterlockLog, 2022, 2024)
