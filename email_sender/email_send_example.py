from email_sender import EmailSender

SMTP_SERVER = 'smtp.gmail.com'
SMTP_PORT = 465
EMAIL_ADDR = 'jek6020@gmail.com'
EMAIL_PASSWORD = 'jachapxeyhkzvoch'

email_sender = EmailSender(SMTP_SERVER, SMTP_PORT, EMAIL_ADDR, EMAIL_PASSWORD)
email_sender.send_email('jek9412@naver.com', '삼성 SDI 인터락 발생', '현재 삼성 SDI 인터락 발생했으므로, 확인 부탁드립니다.')