import cv2
import pyautogui
import numpy as np
import datetime as dt
import time
import threading
import firebase_admin
from firebase_admin import credentials, storage
from uuid import uuid4
import os


def record(equip_name, x, y, w, h):
    now = dt.datetime.now()
    now = now.strftime("%Y_%m_%d_%H_%M")

    print(equip_name + " - " + now + '.avi is recording...')

    # 해상도 설정
    resolution = (w, h)
    # 코덱 설정 (window는 XVID라고함)
    codec = cv2.VideoWriter_fourcc(*'XVID')
    # 저장할 이름 설정 - 단위시간마다 계속 저장할 것이므로 현재시간을 이름으로 가져올 생각
    filename = '{}.avi'.format(now)
    # 저장 경로 설정 - 고정된 경로일 것 같아서 변수화 안해도 될 것이라 생각
    location = "./지옥/"+equip_name
    fps = 10.0
    # 융합
    out = cv2.VideoWriter(location+'/'+filename, codec, fps, resolution)

    # 단위시간에 따른 종료를 구현하기 위해 시작시간 기록
    start_time = time.time()
    
    while True:
            # 스크린샷을 계속 찍어 out에 쌓아서 영상을 생성
            img = pyautogui.screenshot(region=(x, y, w, h)) 
            frame = np.array(img) 
            frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB) 
            out.write(frame) 
            
            # 현재 시간이 시작시간으로부터 nn초 이상 지났을 시 스샷누적 종료
            if time.time() - start_time > 60:
                print(equip_name + " - " + now + '.avi is done !')
                break
    
    # 영상 녹화 종료 및 저장
    out.release()
    cv2.destroyAllWindows()

    # firebase에 영상 업로드
    fileUpload(equip_name, filename, location)
    # local에서 영상 제거
    os.remove(location+'/'+filename)

def do_record(equip_name, x, y, w, h):
     while True:
          record(equip_name, x, y, w, h)


def fileUpload(equip_name, file_name, location):
    # firebase storage에서 파일이 저장될 경로를 설정
    blob = bucket.blob(equip_name+'/'+file_name)
    new_token = uuid4()
    metadata = {"firebaseStorageDownloadTokens": new_token}
    blob.metadata = metadata

    # upload할 파일이 있는 local 폴더 주소
    blob.upload_from_filename(location+'/'+file_name)


# def getCCTVUrl(equip_name, timeline):
#     # 다운로드 URL 생성
#     bucket = storage.bucket()
#     # blob = bucket.blob('6272CMK6/2023_05_03_16_04_22.avi')
#     blob = bucket.blob(f'{equip_name}/{timeline}.avi')
#     url = blob.generate_signed_url(expiration=dt.timedelta(hours=1)) # 만료 시간 설정 가능
#     print(url)
#     return url


# def getCCTVUrl(equip_name, timeline):
#     bucket = storage.bucket()
#     blobs = bucket.list_blobs(prefix=equip_name)

#     latest_blob = None
#     latest_time = None
#     for blob in blobs:
#         if not latest_time or blob.time_created > latest_time:
#             latest_blob = blob
#             latest_time = blob.time_created
    
#     if latest_blob:
#         url = latest_blob.generate_signed_url(expiration=dt.timedelta(hours=12))
#         return url
#     else:
#         print("file empty")
#         return 
    


def getCCTVUrl(equip_name):
    now = dt.datetime.now()
    file_name = now.strftime("%Y_%m_%d_%H_%M")
    url = f'https://firebasestorage.googleapis.com/v0/b/ssafy-a201.appspot.com/o/{equip_name}%2F{file_name}.avi?alt=media'
    return url


# 인증 정보 (personal key)
cred = credentials.Certificate("./ssafy-a201-firebase.json")
# firebase storage 주소
app = firebase_admin.initialize_app(cred, {
    'storageBucket': 'ssafy-a201.appspot.com',
})

bucket = storage.bucket()


thread1 = threading.Thread(target=do_record, args=('HO3IXOQV', 17, 120, 270, 205))
thread2 = threading.Thread(target=do_record, args=('J74JM4W6', 345, 120, 270, 205))
thread3 = threading.Thread(target=do_record, args=('RP3A7CWU', 673, 120, 270, 205))
thread4 = threading.Thread(target=do_record, args=('SJG6EU48', 1001, 120, 270, 205))
thread5 = threading.Thread(target=do_record, args=('TFEISG9E', 1329, 120, 270, 205))


thread1.start()
thread2.start()
thread3.start()
thread4.start()
thread5.start()