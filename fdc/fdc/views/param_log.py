from rest_framework import viewsets
from ..models import ParamLog
from ..serializers import ParamLogSerializer
from datetime import datetime

class ParamLogViewSet(viewsets.ModelViewSet):
    serializer_class = ParamLogSerializer

    def get_queryset(self):
        queryset = ParamLog.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        param_value = self.request.GET.get('param_value', None)
        equipment_id = self.request.GET.get('equipment_id', None)
        param_id = self.request.GET.get('param_id', None)
        recipe_id = self.request.GET.get('recipe_id', None)
        lot_id = self.request.GET.get('lot_id', None)
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)

        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if param_value:
            queryset = queryset.filter(param_value__icontains=param_value)
        if equipment_id:
            queryset = queryset.filter(equipment__equipment_id__icontains=equipment_id)
        if param_id:
            queryset = queryset.filter(param__param_id__icontains=param_id)
        if recipe_id:
            queryset = queryset.filter(recipe__precipe_id__icontains=recipe_id)
        if lot_id:
            queryset = queryset.filter(lot__lot_id__icontains=lot_id)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))



        return queryset