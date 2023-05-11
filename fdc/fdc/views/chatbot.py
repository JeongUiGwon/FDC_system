from langchain import OpenAI, SQLDatabase
from langchain.chains import SQLDatabaseSequentialChain
from django.http import JsonResponse
import os
import sys
import urllib.request
import json

# import urllib

os.environ["OPENAI_API_KEY"] = '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'
API_KEY = os.getenv('OPENAI_API_KEY')


def translate(text, source, target):
    text = text
    source = source
    target = target

    encText = urllib.parse.quote(text)
    data = f'source={source}&target={target}&text=' + encText

    url = "https://openapi.naver.com/v1/papago/n2mt"
    client_id = "d4eib1sxSkFmOuwKMrsx"
    client_secret = "je4rsFkau8"

    request = urllib.request.Request(url)
    request.add_header("X-Naver-Client-Id", client_id)
    request.add_header("X-Naver-Client-Secret", client_secret)

    response = urllib.request.urlopen(request, data=data.encode("utf-8"))
    rescode = response.getcode()

    if rescode == 200:
        response_body = response.read()
        decode = json.loads(response_body.decode('utf-8'))
        result = decode['message']['result']['translatedText']
        return result
    else:
        return 'Error Code:' + str(rescode)


def chatbot(request):
    db = SQLDatabase.from_uri(
        "postgresql://cms:1234@localhost:5432/fdc",
        include_tables=['equipment', 'recipe', 'param', 'param_log', 'interlock_log', 'param_history',
                        'recipe_history'],
        # include_tables= ['param_log'],
        sample_rows_in_table_info=2
    )

    # setup llm
    llm = OpenAI(temperature=0)

    # Create db chain
    QUERY = """
    When given a question, please follow these steps:
    1. Create a syntactically correct Postgresql query to run.
    2. Look at the results of the query and return the answer.
    
    각 테이블의 한글명은 다음과 같아
    equipment:설비, param:항목, recipe:레시피, param_log: 항목 로그, interlock_log: 인터락 로그, param_history:항목 이력(기록), interlock_history: 인터락 이력(기록) 
    
    There are conditions.
    1. Use public schema
    2. in the table name exclude tables with "auth" and "django"
    3. Partitioned tables are considered one type
    
    Use the following format:
    
    Question: "Question here"
    SQLQuery: "SQL Query to run"
    SQLResult: "Result of the SQLQuery"
    Answer: "Final answer here as korean"
    
    {question}
    """

    # Setup the database chain
    db_chain = SQLDatabaseSequentialChain.from_llm(llm=llm, database=db, verbose=True, return_intermediate_steps=True)

    user_question = request.GET.get('question', None)
    # print(f'user question: {user_question}')
    # user_question = translate(user_question, 'ko', 'en')
    print(f'translate question: {user_question}')

    question = QUERY.format(question=user_question)
    answer = db_chain(question)['intermediate_steps']

    if user_question is None or answer == '':
        answer = 'not valid'
        response_data = ''

    else:
        response_data = {'query': answer[0], 'result': answer[1]}
        # response_data = {'answer': answer}

    # print(type(answer))
    return JsonResponse(response_data)
