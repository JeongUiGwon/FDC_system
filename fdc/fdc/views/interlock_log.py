from rest_framework import viewsets
from ..models import InterlockLog
from ..serializers import InterlockLogSerializer

class InterlockLogViewSet(viewsets.ModelViewSet):
    queryset = InterlockLog.objects.all()
    serializer_class = InterlockLogSerializer
