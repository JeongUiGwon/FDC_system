from rest_framework import viewsets
from fdc.models import EquipmentState
from fdc.serializers import EquipmentStateSerializer

class EquipmentStateViewSet(viewsets.ModelViewSet):
    queryset = EquipmentState.objects.all()
    serializer_class = EquipmentStateSerializer
