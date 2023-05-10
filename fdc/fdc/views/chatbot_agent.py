from langchain.agents import create_sql_agent
from langchain.agents.agent_toolkits import SQLDatabaseToolkit
from langchain.sql_database import SQLDatabase
from langchain.llms.openai import OpenAI
from langchain.agents import AgentExecutor
import os
from django.views import generic
from django.http import JsonResponse

os.environ["OPENAI_API_KEY"] = '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'
API_KEY = os.getenv('OPENAI_API_KEY')


def chatbot_agent(request):
    print(request)
    db = SQLDatabase.from_uri(
        "postgresql://cms:1234@localhost:5432/fdc",
    )
    llm = OpenAI(temperature=0)
    toolkit = SQLDatabaseToolkit(db=db, llm=llm)

    agent_executor = create_sql_agent(
        llm=OpenAI(temperature=0),
        toolkit=toolkit,
        verbose=True
    )

    answer = agent_executor.run(request.GET.get('question', None))
    if answer == '':
        answer = 'not valid'
    response_data = {'answer': answer}

    # print(type(answer))
    return JsonResponse(response_data)
