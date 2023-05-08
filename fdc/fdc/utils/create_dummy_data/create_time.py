from datetime import datetime, timedelta
import random
def random_past_datetime():
    past_time = datetime.now() - timedelta(days=random.randint(0, 365),
                                      hours=random.randint(0, 23),
                                      minutes=random.randint(0, 59),
                                      seconds=random.randint(0, 59))
    return past_time.strftime("%Y-%m-%d %H:%M:%S")

def random_future_datetime_from_past():
    past_time = datetime.strptime(random_past_datetime(), "%Y-%m-%d %H:%M:%S")
    future_time = past_time + timedelta(days=random.randint(0, 365),
                                        hours=random.randint(0, 23),
                                        minutes=random.randint(0, 59),
                                        seconds=random.randint(0, 59))
    return future_time.strftime("%Y-%m-%d %H:%M:%S")