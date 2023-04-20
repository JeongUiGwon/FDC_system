DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.mysql', # 사용할 DB의 종류
        'NAME': 'fdc',    # DB 이름
        'USER': 'tyms0503',       # DB 계정 이름
        'PASSWORD': '11111111', # DB 계정의 패스워드
        'HOST': 'localhost',    # IP
        'PORT': '3306',         # 포트 번호
    }
}

SECRET_KEY = 'django-insecure-n@(x5(hys_2y*8cv3&4u(ma_$^^04drseqe=1s6^s(#8l9@k3*'
