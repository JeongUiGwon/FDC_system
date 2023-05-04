from rest_framework import viewsets
from ..models import Equipment
from ..serializers import EquipmentSerializer

class EquipmentViewSet(viewsets.ModelViewSet):
    serializer_class = EquipmentSerializer

    def get_queryset(self):
        queryset = Equipment.objects.all()

        # 쿼리 파라미터에서 필터링 값 가져오기
        equipment_id = self.request.GET.get('equipment_id', None)
        equipment_use = self.request.GET.get('equipment_use', None)
        equipment_state = self.request.GET.get('equipment_state', None)
        equipment_mode = self.request.GET.get('equipment_mode', None)
        creator_name = self.request.GET.get('creator_name', None)
        interlock_id = self.request.GET.get('interlock_id', None)

        # 필터링 값이 제공된 경우 필터링 적용
        if equipment_id:
            equipment_id_list = equipment_id.split(',')
            queryset = queryset.filter(equipment_id__icontains=equipment_id_list)
        if equipment_use:
            queryset = queryset.filter(equipment_use__icontains=equipment_use)
        if equipment_state:
            queryset = queryset.filter(equipment_state__icontains=equipment_state)
        if equipment_mode:
            queryset = queryset.filter(equipment_mode__icontains=equipment_mode)
        if creator_name:
            queryset = queryset.filter(creator_name__icontains=creator_name)
        if interlock_id:
            queryset = queryset.filter(interlock_id__icontains=interlock_id)

        return queryset
