import pymysql

def check():
    conn = pymysql.connect(host='172.26.6.41',
                            user='cms',
                            password='11111111',
                            db='minki',
                            charset='utf8')
    cursor = conn.cursor()

    data = {"created_at": "2023-05-01T14:30:45.973232", "data_value": 11.861240, "equipment_id": "6272CMK6", "lot_id": "1", "param_id": "N7I6IXN7OSNS22O", "recipe_id": "NNX12IIWNWH1PPQX733M"}

    equipment_id = data["equipment_id"]
    param_id = data["param_id"]
    recipe_id = data["recipe_id"]

    param_sql = f'SELECT * FROM param_test WHERE param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
    cursor.execute(param_sql)
    param = cursor.fetchone()
    cursor.close()
    param_level = param[1]

    recipe_sql = f'SELECT * FROM recipe_test WHERE recipe_id = "{recipe_id}" AND equipment_id = "{equipment_id}" AND param_id = "{param_id}"'
    cursor.execute(recipe_sql)
    recipe = cursor.fetchone()
    cursor.close()
    lsl = recipe[2]
    usl = recipe[3]
    lsl_interlock_action = recipe[4]
    usl_interlock_action = recipe[5]

    master_data_sql = f'SELECT * FROM master_data WHERE recipe_id = "{recipe_id}" AND equipment_id = "{equipment_id}" AND param_id = "{param_id}"'
    cursor.execute(master_data_sql)
    mes = cursor.fetchone()
    cursor.close()

    if param_level != mes[3]:
        update_sql = f'UPDATE param_test SET param_level = "{mes[3]}" param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
        cursor.execute(update_sql)
        conn.commit()
        cursor.close()
    if usl != mes[4]:
        update_sql = f'UPDATE recipe_test SET usl = "{mes[4]}" WHERE recipe_id = "{recipe_id}" AND param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
        cursor.execute(update_sql)
        conn.commit()
        cursor.close()
    if lsl != mes[5]:
        update_sql = f'UPDATE recipe_test SET lsl = "{mes[5]}" WHERE recipe_id = "{recipe_id}" AND param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
        cursor.execute(update_sql)
        conn.commit()
        cursor.close()
    if usl_interlock_action != mes[6]:
        update_sql = f'UPDATE recipe_test SET usl_interlock_action = "{mes[6]}" WHERE recipe_id = "{recipe_id}" AND param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
        cursor.execute(update_sql)
        conn.commit()
        cursor.close()
    if lsl_interlock_action != mes[7]:
        update_sql = f'UPDATE recipe_test SET lsl_interlock_action = "{mes[7]}" WHERE recipe_id = "{recipe_id}" AND param_id = "{param_id}" AND equipment_id = "{equipment_id}"'
        cursor.execute(update_sql)
        conn.commit()
        cursor.close()

check()
    




## | recipe_id            | varchar(50) | NO   | PRI | NULL    |       |
## | equipment_id         | varchar(50) | YES  |     | NULL    |       |
## | param_id             | varchar(50) | YES  |     | NULL    |       |
# | param_level          | varchar(50) | YES  |     | NULL    |       |
# | usl                  | int         | YES  |     | NULL    |       |
# | lsl                  | int         | YES  |     | NULL    |       |
# | usl_interlock_action | varchar(50) | YES  |     | NULL    |       |
# | lsl_interlock_action | varchar(50) | YES  |     | NULL    |       |
