from rest_framework import viewsets
from ..models import LotLog
from ..serializers import LotLogSerializer

class LotLogViewSet(viewsets.ModelViewSet):
    queryset = LotLog.objects.all()
    serializer_class = LotLogSerializer
