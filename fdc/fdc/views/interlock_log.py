from rest_framework import viewsets
from ..models import InterlockLog
from ..serializers import InterlockLogSerializer
import datetime

class InterlockLogViewSet(viewsets.ModelViewSet):
    serializer_class = InterlockLogSerializer

    def get_queryset(self):
        queryset = InterlockLog.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        equipment_id = self.request.GET.get('equipment_id', None)
        param_id = self.request.GET.get('param_id', None)
        recipe_id = self.request.GET.get('recipe_id', None)
        interlock_type = self.request.GET.get('interlock_type', None)
        out_count = self.request.GET.get('out_count', None)
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)

        if factory_id:
            factory_id_list = factory_id.split(',')
            queryset = queryset.filter(factory_id__in=factory_id_list)
        if equipment_id:
            equipment_id_list = equipment_id.split(',')
            queryset = queryset.filter(equipment__equipment_id__in=equipment_id_list)
        if param_id:
            param_id_list = param_id.split(',')
            queryset = queryset.filter(param__param_id__in=param_id_list)
        if recipe_id:
            recipe_id_list = recipe_id.split(',')
            queryset = queryset.filter(recipe__recipe_id__icontains=recipe_id_list)
        if interlock_type:
            queryset = queryset.filter(interlock_type__icontains=interlock_type)
        if out_count:
            queryset = queryset.filter(out_count__icontains=out_count)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))

        return queryset
