from rest_framework import viewsets
from fdc.models import InterlockLog
from fdc.serializers import InterlockLogSerializer

class InterlockLogViewSet(viewsets.ModelViewSet):
    queryset = InterlockLog.objects.all()
    serializer_class = InterlockLogSerializer
