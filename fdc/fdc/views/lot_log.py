from rest_framework import viewsets
from fdc.models import LotLog
from fdc.serializers import LotLogSerializer

class LotLogViewSet(viewsets.ModelViewSet):
    queryset = LotLog.objects.all()
    serializer_class = LotLogSerializer
