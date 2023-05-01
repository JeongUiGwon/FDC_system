DATABASES = {
    'default': {
        # 'ENGINE': 'django.db.backends.postgresql', # 사용할 DB의 종류
        'ENGINE': 'psqlextra.backend',

        'NAME': 'fdc',    # DB 이름
        'USER': 'cms',       # DB 계정 이름
        'PASSWORD': '1234', # DB 계정의 패스워드
        'HOST': 'localhost',    # IP
        'PORT': '5432',         # 포트 번호
    }
}

SECRET_KEY = 'django-insecure-n@(x5(hys_2y*8cv3&4u(ma_$^^04drseqe=1s6^s(#8l9@k3*'
