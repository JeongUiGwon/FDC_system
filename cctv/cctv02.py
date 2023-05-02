import cv2
import pyautogui
import numpy as np
import datetime as dt
import time


def record():
    now = dt.datetime.now()
    now = now.strftime("%Y_%m_%d_%H_%M_%S")

    print(now + '.avi is recording...')

    # 해상도 설정
    resolution = (1920,1080)
    # 코덱 설정 (window는 XVID라고함)
    codec = cv2.VideoWriter_fourcc(*'XVID')
    # 저장할 이름 설정 - 단위시간마다 계속 저장할 것이므로 현재시간을 이름으로 가져올 생각
    filename = '{}.avi'.format(now)
    # 저장 경로 설정 - 고정된 경로일 것 같아서 변수화 안해도 될 것이라 생각
    location = "C:/Users/SSAFY/Desktop/gitlab/자율/CCTV/지옥"
    fps = 22.0 
    # 융합
    out = cv2.VideoWriter(location+'/'+filename, codec, fps, resolution)

    # 단위시간에 따른 종료를 구현하기 위해 시작시간 기록
    start_time = time.time()
    
    while True:
            # 스크린샷을 계속 찍어 out에 쌓아서 영상을 생성
            img = pyautogui.screenshot() 
            frame = np.array(img) 
            frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB) 
            out.write(frame) 
            
            # 현재 시간이 시작시간으로부터 nn초 이상 흘렀거나 q를 누를 시 스샷누적 종료
            if time.time() - start_time > 10 or cv2.waitKey(1) == ord('q'):
                print(now + '.avi is done !')
                break
    
    # 영상 녹화 종료 및 저장
    out.release()
    cv2.destroyAllWindows()


# 녹화 함수 무한루프
while True:
     record()
