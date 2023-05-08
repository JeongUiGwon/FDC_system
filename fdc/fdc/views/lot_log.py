from rest_framework import viewsets
from ..models import LotLog
from ..serializers import LotLogSerializer
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema
from datetime import datetime

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
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)

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
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))

        return queryset

    @swagger_auto_schema(
        operation_description="Get a list of LotLog objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('lot_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by lot ID."),
            openapi.Parameter('factory_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by factory ID."),
            openapi.Parameter('lot_state', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by lot state."),
            openapi.Parameter('equipment_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by equipment name."),
            openapi.Parameter('param_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by parameter name."),
            openapi.Parameter('recipe_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by recipe name."),
            openapi.Parameter('start_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by start date (format: YYYY-MM-DD HH:MM)."),
            openapi.Parameter('end_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by end date (format: YYYY-MM-DD HH:MM)."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(LotLogViewSet, self).list(request, *args, **kwargs)