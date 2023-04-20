from rest_framework import viewsets
from fdc.models import ParamHistory
from fdc.serializers import ParamHistorySerializer

class ParamHistoryViewSet(viewsets.ModelViewSet):
    queryset = ParamHistory.objects.all()
    serializer_class = ParamHistorySerializer
