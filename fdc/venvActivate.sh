#!/bin/bash

source env/bin/activate

cd /var/lib/jenkins/workspace/A201_FDC_Server/fdc

python3 manage.py makemigrations
python3 manage.py migrate

echo "Migrations done"

source runserver

echo "runserver done"