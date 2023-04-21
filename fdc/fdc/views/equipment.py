from rest_framework import viewsets
from fdc.models import Equipment
from fdc.serializers import EquipmentSerializer

class EquipmentViewSet(viewsets.ModelViewSet):
    queryset = Equipment.objects.all()
    serializer_class = EquipmentSerializer
