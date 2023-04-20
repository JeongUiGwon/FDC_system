from rest_framework import viewsets
from fdc.models import ParamLog
from fdc.serializers import ParamLogSerializer

class ParamLogViewSet(viewsets.ModelViewSet):
    queryset = ParamLog.objects.all()
    serializer_class = ParamLogSerializer
