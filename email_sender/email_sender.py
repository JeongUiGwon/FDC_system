import smtplib
from email.message import EmailMessage

class EmailSender:
    def __init__(self, server, port, email_addr, email_password):
        self.server = server
        self.port = port
        self.email_addr = email_addr
        self.email_password = email_password
        self.smtp = smtplib.SMTP_SSL(server, port)

    def send_email(self, to_addr, subject, body):
        message = EmailMessage()
        message.set_content(body)
        message["Subject"] = subject
        message["From"] = self.email_addr
        message["To"] = to_addr

        self.smtp.login(self.email_addr, self.email_password)
        self.smtp.send_message(message)
        self.smtp.quit()