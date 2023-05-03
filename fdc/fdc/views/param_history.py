from rest_framework import viewsets
from ..models import ParamHistory
from ..serializers import ParamHistorySerializer

class ParamHistoryViewSet(viewsets.ModelViewSet):
    queryset = ParamHistory.objects.all()
    serializer_class = ParamHistorySerializer
