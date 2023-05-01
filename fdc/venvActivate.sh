#!/bin/bash

source env/bin/activate

cd /var/lib/jenkins/workspace/A201_FDC_Server/fdc

python3 manage.py makemigrations
python3 manage.py migrate

echo "Migrations done"

echo $PWD

python3 manage.py runserver 0.0.0.0:8000

echo "runserver done"