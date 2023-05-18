import os
from celery import Celery

# Django의 settings 모듈을 Celery의 기본 설정으로 사용하도록 지정
os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'app.settings')

app = Celery('fdc')

# Celery에게 Django 프로젝트의 설정 파일을 사용하도록 지시합니다.
# 'CELERY_'로 시작하는 설정을 읽어 들입니다.
app.config_from_object('django.conf:settings', namespace='CELERY')

# Django 앱을 auto discover하도록 합니다.
# tasks.py 파일에서 task를 찾습니다.
app.autodiscover_tasks()

# Redis를 메시지 브로커로 설정합니다.
app.conf.broker_url = 'redis://localhost:6379/0'

# 결과 백엔드로 Redis를 설정합니다.
app.conf.result_backend = 'redis://localhost:6379/0'
