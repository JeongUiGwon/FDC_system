import csv,json,time,threading, pymysql

def saveFile():
        conn = pymysql.connect(host='172.26.6.41',
                               user='cms',
                               password='11111111',
                               db='minki',
                               charset='utf8')
        sql = "INSERT INTO test (name, age, gender) VALUES (%s, %s, %s)"


        data = [{'이름': '궈니궈니', '나이': '25', '성별': '여성'},
                {'이름': '비니비니', '나이': '30', '성별': '남성'},
                {'이름': '서니서니', '나이': '35', '성별': '남성'},
                {'이름': '화니화니', '나이': '40', '성별': '여성'},
                {'이름': '띵서띵서', '나이': '45', '성별': '남성'}]

        with conn:
                with conn.cursor() as cur:
                        for i in range(5):
                                cur.execute(sql, (data[i]['이름'],data[i]['나이'],data[i]['성별']))
                        conn.commit()

        # data to string
        data_str = json.dumps(data)

        # data_str to dict
        data_json = json.loads(data_str)

        # dict data write to csv file
        with open('data.csv', 'w', newline='') as file:
                fieldnames = ['이름', '나이', '성별']
                writer = csv.DictWriter(file, fieldnames=fieldnames)
                writer.writeheader()
                for row in data_json:
                        writer.writerow(row)

        file.close()

        # interval with 60 secs
        threading.Timer(60, saveFile).start()

saveFile()