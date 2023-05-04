from rest_framework import viewsets
from ..models import ParamLog
from ..serializers import ParamLogSerializer
from datetime import datetime

class ParamLogViewSet(viewsets.ModelViewSet):
    serializer_class = ParamLogSerializer

    def get_queryset(self):
        queryset = ParamLog.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        equipment_id = self.request.GET.get('equipment_id', None)
        param_id = self.request.GET.get('param_id', None)
        recipe_id = self.request.GET.get('recipe_id', None)
        lot_id = self.request.GET.get('lot_id', None)
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
        if lot_id:
            lot_id_list = lot_id.split(',')
            queryset = queryset.filter(lot__lot_id__in=lot_id_list)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))



        return queryset