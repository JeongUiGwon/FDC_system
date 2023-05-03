from rest_framework import viewsets
from fdc.models import EquipmentState
from fdc.serializers import EquipmentStateSerializer

class EquipmentStateViewSet(viewsets.ModelViewSet):
    serializer_class = EquipmentStateSerializer

    def get_queryset(self):
        queryset = EquipmentState.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        mode = self.request.GET.get('mode', None)
        status = self.request.GET.get('status', None)

        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if mode:
            queryset = queryset.filter(mode__icontains=mode)
        if status:
            queryset = queryset.filter(status__icontains=status)

        return queryset
