from rest_framework import viewsets
from ..models import Param
from ..serializers import ParamSerializer

class ParamViewSet(viewsets.ModelViewSet):
    serializer_class = ParamSerializer

    def get_queryset(self):
        queryset = Param.objects.all()

        param_id = self.request.GET.get('param_id', None)
        param_name = self.request.GET.get('param_name', None)
        param_level = self.request.GET.get('param_level', None)
        param_state = self.request.GET.get('param_state', None)
        creator_name = self.request.GET.get('creator_name', None)
        equipment_id = self.request.GET.get('equipment_id', None)

        if param_id:
            param_id_list = param_id.split(',')
            queryset = queryset.filter(param_id__in=param_id_list)
        if param_level:
            queryset = queryset.filter(param_level__icontains=param_level)
        if param_state:
            queryset = queryset.filter(param_state__icontains=param_state)
        if creator_name:
            queryset = queryset.filter(creator_name__icontains=creator_name)
        if equipment_id:
            queryset = queryset.filter(equipment__equipment_id__icontains=equipment_id)

        return queryset
