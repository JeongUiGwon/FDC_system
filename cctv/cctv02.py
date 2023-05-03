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
    now = now.strftime("%Y_%m_%d_%H_%M_%S")

    print(equip_name + " - " + now + '.avi is recording...')

    # 해상도 설정
    resolution = (w, h)
    # 코덱 설정 (window는 XVID라고함)
    codec = cv2.VideoWriter_fourcc(*'XVID')
    # 저장할 이름 설정 - 단위시간마다 계속 저장할 것이므로 현재시간을 이름으로 가져올 생각
    filename = '{}.avi'.format(now)
    # 저장 경로 설정 - 고정된 경로일 것 같아서 변수화 안해도 될 것이라 생각
    location = "C:/Users/SSAFY/Desktop/gitlab/자율/CCTV/지옥/"+equip_name
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
            
            # 현재 시간이 시작시간으로부터 nn초 이상 흘렀거나 q를 누를 시 스샷누적 종료
            if time.time() - start_time > 10 or cv2.waitKey(1) == ord('q'):
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


# 인증 정보 (personal key)
cred = credentials.Certificate("C:/Users/SSAFY/Desktop/gitlab/자율/CCTV/ssafy-a201-firebase.json")
# firebase storage 주소
app = firebase_admin.initialize_app(cred, {
    'storageBucket': 'ssafy-a201.appspot.com',
})

bucket = storage.bucket()


thread1 = threading.Thread(target=do_record, args=('설비1', 0, 0, 300, 300))
thread2 = threading.Thread(target=do_record, args=('설비2', 300, 0, 300, 300))
thread3 = threading.Thread(target=do_record, args=('설비3', 600, 0, 300, 300))
thread4 = threading.Thread(target=do_record, args=('설비4', 0, 300, 300, 300))
thread5 = threading.Thread(target=do_record, args=('설비5', 300, 300, 300, 300))


thread1.start()
thread2.start()
thread3.start()
thread4.start()
thread5.start()