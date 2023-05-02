from rest_framework import viewsets
from fdc.models import LotLog
from fdc.serializers import LotLogSerializer

class LotLogViewSet(viewsets.ModelViewSet):
    serializer_class = LotLogSerializer

    def get_queryset(self):
        queryset = LotLog.objects.all()

        lot_id = self.request.GET.get('lot_id', None)
        factory_id = self.request.GET.get('factory_id', None)
        lot_state = self.request.GET.get('lot_state', None)
        equipment_name = self.request.GET.get('equipment_name', None) # 쿼리 파라미터에서 equipment_name 가져오기
        param_name = self.request.GET.get('param_name', None) # 쿼리 파라미터에서 param_name 가져오기
        recipe_name = self.request.GET.get('recipe_name', None) # 쿼리 파라미터에서 param_name 가져오기

        if lot_id:
            queryset = queryset.filter(lot_id__icontains=lot_id)
        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if lot_state:
            queryset = queryset.filter(lot_state__icontains=lot_state)
        if equipment_name:
            queryset = queryset.filter(equipment__equipment_name__icontains=equipment_name)  # equipment_name으로 필터링
        if param_name:
            queryset = queryset.filter(param__param_name__icontains=param_name)  # param_name으로 필터링
        if recipe_name:
            queryset = queryset.filter(recipe__recipe_name__icontains=recipe_name)  # equipment_name으로 필터링

        return queryset

