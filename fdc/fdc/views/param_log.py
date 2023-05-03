from rest_framework import viewsets
from ..models import ParamLog
from ..serializers import ParamLogSerializer

class ParamLogViewSet(viewsets.ModelViewSet):
    queryset = ParamLog.objects.all()
    serializer_class = ParamLogSerializer
