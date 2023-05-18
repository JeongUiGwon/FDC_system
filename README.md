# 🏭 배터리 제조 기술 설비 이상 감지 시스템(FDC 시스템) 

### 삼성 SDI 연계 PJT



## 프로젝트 진행 기간

2023.04.10(월) ~ 2023.05.26(금)  
SSAFY 8기 2학기 삼성 SDI 연계 프로젝트 - 배터리 제조 기술 설비 이상 감지 시스템(FDC 시스템)



## 🚩 사전 지식

- FDC (Fault Detection & Classification)

  - 설비 데이터를 실시간으로 모니터링하여 설비의 이상을 감지하는 시스템으로, 불량 발생 및 중대 고장을 사전에 예방하는 것을 목적으로 함

- MES (Manufacturing Execution System)

  - 스마트 팩토리의 핵심인 통합 생산 관리 시스템으로, 발주부터 품질검사까지 공정 전체의 활동을 관리함

- Interlock

  - 특정 조건 상에서 설비의 작동을 중지시키는 제어 명령을 의미

  


## 🚩 기획 배경

- 배터리 공정에서 불량 관리는 매우 중요한 과제.
- 설비가 MES로 직접 양불 판정을 보고하는 기존 구조는 설비 자체의 결함으로 판정에 오류가 발생할 시 불량 배터리가 후공정으로 넘어가 리콜 사태가 발생할 수 있다는 치명적 단점이 있음
- 따라서 효율적이고 안정적인 제조 설비 시스템 운영을 위해 모든 설비 데이터를 실시간으로 모니터링 및 분석할 수 있는 FDC 시스템을 구축하여 설비에 이상이 발견될 경우 MES로 Interlock 지시를 내려 불량 발생을 최소화시키고자 함

![image.png](./image.png)					![image-1.png](./image-1.png)




## 🚩 주요 구현 기능

1. 실시간 설비 데이터 모니터링

2. 스마트 서치

3. 오토 레인지

4. 풀패턴 (구현 중)

   


## 🚩 시스템 아키텍처


![Image Pasted at 2023-5-18 01-33](https://github.com/isangbin/Cloud/assets/107028275/32ef8bb9-8ae5-4eee-b632-57f96964a55f)


1. Language

   - C#
   - Python
   - Java
2. Framework

   - WPF
3. DB

   - Firebase
   - PostgreSQL
4. OS

   - Windows
   - Linux
5. Server

   - AWS EC2
   - Nginx
6. CI/CD

   - Jenkins
   - Docker
7. Test

   - Sonarqube



## 🚩 개발 환경

1. **Virtual Factory**

- Simulator : AnyLogic (버전 : 8.8.2)

- Server : Python (버전 : 3.8.10)

- Client : Java (버전 : JDK 8)

- DBMS : PostgreSQL

- IDE : VS Code / AnyLogic / MovaXterm



2. **Win App**

- IDE : Visual Studio 2022 (버전 : 17.5.4 이상)

- Framework : WPF (버전 : .NET Framework 4.7.2)

- Package

  - MaterialDesignThemes (ver.4.8.0)
    - UI/UX 디자인 제공 패키지

  - FirebaseAuthentication.net (ver.4.0.2)
    - firebase 연동

  - Microsoft.Extensions.Hosting (ver.7.0.1)
    - firebase 연동에 필요한 호스팅

  - FontAwesome.Sharp (ver.6.3.0)
    - 폰트
  - LiveChart.WPF(ver.0.9.7)
    - 차트



3. **Backend**

   - 개발환경: AWS ec2 Ubuntu20.04

   - IDE: Pycharm Professional Edition

   - Framework: Django 4.2

   - DBMS: PostgreSQL

   - Package
     - [**requirements**](https://lab.ssafy.com/s08-final/S08P31A201/-/blob/develop/fdc/requirements.txt)

## 🙆 협업 툴


- GitLab
- Notion
- JIRA
- MatterMost



## 🙆 협업 환경

- Gitlab
  - 코드 버전 관리
  - Jira와 연동하여 일정 관리
  - 커밋 컨벤션 준수

- JIRA
  - 매주 일정에 따른 업무를 할당하여 Sprint 진행
  - JIRA 컨벤션 준수

- 회의
  - 아침마다 스크럼 회의 진행
  - 주별로 전 파트 코드리뷰 진행
  - 그라운드 룰 준수

- Notion
  - 각종 문서 아카이빙과 회의록 보관
  - 기능명세서, 이해관계자, 유즈케이스 시나리오 등 문서 보관
  - 코딩 컨벤션 정리
  - 프로젝트 일정 정리
  - 그라운드 룰 명시


## 🙆  팀원 역할 분배


### Window App(Frontend)

- 정의권 : C# WPF 윈도우 프로그램 개발

### FDC Server(Backend/DB)

- 최명서 : Django FDC Sever 개발, PostgreSQL DB 구축

### Virtual Factory

- 김지선 : 시뮬레이터(AnyLogic)를 사용한 공정 환경 구성
- 조성환 : 시뮬레이터(AnyLogic)를 사용한 공정 환경 구성, 발표 담당

### Functions (Backend)

- 임상빈 : Factory - FDC 통신, openCV 영상처리, torch 머신러닝
- 채민기 : MES 구축, SIM - FDC - MES TCP/IP 통신 구현


## 🚩 프로젝트 산출물


- 기능명세서

  ![기능명세서](https://github.com/isangbin/Cloud/assets/107028275/4d4203ea-7bda-452e-ac06-d8cbe6a492fb)


- ERD

  ![erd](https://github.com/isangbin/Cloud/assets/107028275/089452a2-16bd-4287-bb5c-bdc4872cb4dd)

- API 명세서

  ![api명세서](https://github.com/isangbin/Cloud/assets/107028275/0725412d-af05-4ca7-954e-75c80a88858e)

- [Wireframe](https://www.figma.com/file/O4j5CtW00BeuhHcqGGodPV/%EB%B0%B0%ED%84%B0%EB%A6%AC-%EC%A0%9C%EC%A1%B0-%EC%84%A4%EB%B9%84-%EC%9D%B4%EC%83%81-%EA%B0%90%EC%A7%80-%EC%8B%9C%EC%8A%A4%ED%85%9C-%EA%B5%AC%EC%B6%95?node-id=1-3&t=Y9BnjpzipoTmGEQo-0)

- [Figma](https://www.figma.com/file/f4IYV7SEUPZvf7MYa5bayh/A201_FDC-System?type=design&node-id=0-1&t=sd0TdWBnadMjzId0-0)

## 🚩: 프로젝트 결과물

