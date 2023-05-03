from rest_framework import viewsets
from ..models import EquipmentState
from ..serializers import EquipmentStateSerializer

class EquipmentStateViewSet(viewsets.ModelViewSet):
    queryset = EquipmentState.objects.all()
    serializer_class = EquipmentStateSerializer
