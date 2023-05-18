- 개발 환경 가이드

1. Virtual Factory

    1-1. Simulator : AnyLogic (버전 : 8.8.2)
    1-2. Server : Python (버전 : 3.8.10)
    1-3. Client : Java (버전 : JDK 8)
    1-4. DBMS : PostgreSQL
    1-5. IDE : VS Code / AnyLogic / MovaXterm

2. Win App

    2-1. IDE : Visual Studio 2022 (버전 : 17.5.4 이상)
    2-2. Framework : WPF (버전 : .NET Framework 4.7.2)
    2-3. Package
        2-3-1. MaterialDesignThemes (ver.4.8.0)
            - UI/UX 디자인 제공 패키지
        2-3-2. [FirebaseAuthentication.net](http://FirebaseAuthentication.net) (ver.4.0.2)
            - firebase 연동
        2-3-3. [Microsoft.Extensions.Hosting](http://Microsoft.Extensions.Hosting) (ver.7.0.1)
            - firebase 연동에 필요한 호스팅
        2-3-4. [FontAwesome.Sharp](http://FontAwesome.Sharp) (ver.6.3.0)
            - 폰트
        2-3-5. LiveChart.WPF(ver.0.9.7)
            - 차트

3. Backend

    3-1. 개발환경: AWS ec2 Ubuntu20.04
    3-2. IDE: Pycharm Professional Edition
    3-3. Framework: Django 4.2
    3-4. DBMS: PostgreSQL
    3-5. Package
    3-6. [**requirements**](https://lab.ssafy.com/s08-final/S08P31A201/-/blob/develop/fdc/requirements.txt)


-----------------------------------------------------------------------------------------------------------------------------

- 빌드 및 배포

1. [GitLab] SOM_Setup 폴더 윈도우 어플리케이션 실행
2. [GitLab] fdc 폴더 코드 run server
3. [GitLab] SocketServer 폴더 코드 실행
4. [GitLab] sim 폴더 model 파일 실행


-----------------------------------------------------------------------------------------------------------------------------

- DB 정보

[GitLab] fdc/my_settings.py 에서 확인 가능


-----------------------------------------------------------------------------------------------------------------------------

- 배포 시 특이 사항

1. Auto Range 

    비동기 작업/큐 스케쥴러 실행
    celery -A fdc worker --loglevel=info
    celery -A fdc beat --loglevel=info


-----------------------------------------------------------------------------------------------------------------------------

- 시연 시나리오

1. 시뮬레이터

    1-1. 소켓 서버 코드 실행 (python3 fdc.py / python3 mes.py)
    1-2. AnyLogic 에서 model run & 뷰 포인트 'CCTV'로 이동
    1-3. 배속 조정
    1-4. Interlock 버튼으로 이상 데이터 부여
    1-5. Restart 버튼으로 조치

2. APP (좌측 탭 순서로 시연)

    2-1. 대쉬보드 소개 / 스마트 서치 소개
    2-2. 설비 / 항목 / 데이터 소개
    2-3. 필터링 기능으로 인터락 소개
    2-4. 인터락 세부 사항 소개
    2-5. CCTV 영상 소개
    2-6. Auto Range / Full Pattern 소개
    2-7. 유저 관리 소개

3. Mail Check
    3-1. 인터락 설비 메일 수신 확인