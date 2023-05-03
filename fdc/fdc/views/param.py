from rest_framework import viewsets
from fdc.models import Param
from fdc.serializers import ParamSerializer

class ParamViewSet(viewsets.ModelViewSet):
    serializer_class = ParamSerializer

    def get_queryset(self):
        queryset = Param.objects.all()

        param_id = self.request.GET.get('param_id', None)
        param_name = self.request.GET.get('param_name', None)
        param_level = self.request.GET.get('param_level', None)
        param_state = self.request.GET.get('param_state', None)
        creator_name = self.request.GET.get('creator_name', None)
        equipment_name = self.request.GET.get('equipment_name', None) # 쿼리 파라미터에서 equipment_name 가져오기

        if param_id:
            queryset = queryset.filter(param_id__icontains=param_id)
        if param_name:
            queryset = queryset.filter(param_name__icontains=param_name)
        if param_level:
            queryset = queryset.filter(param_level__icontains=param_level)
        if param_state:
            queryset = queryset.filter(param_state__icontains=param_state)
        if creator_name:
            queryset = queryset.filter(creator_name__icontains=creator_name)
        if equipment_name:
            queryset = queryset.filter(equipment__equipment_name__icontains=equipment_name)  # equipment_name으로 필터링

        return queryset
