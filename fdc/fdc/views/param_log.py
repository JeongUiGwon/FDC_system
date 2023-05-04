from rest_framework import viewsets
from ..models import ParamLog
from ..serializers import ParamLogSerializer
from datetime import datetime
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema

class ParamLogViewSet(viewsets.ModelViewSet):
    """
    hihih
    """
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

    @swagger_auto_schema(
        operation_description="Get a list of ParamLog objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('factory_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of factory IDs to filter by."),
            openapi.Parameter('equipment_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of equipment IDs to filter by."),
            openapi.Parameter('param_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of parameter IDs to filter by."),
            openapi.Parameter('recipe_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of recipe IDs to filter by."),
            openapi.Parameter('lot_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of lot IDs to filter by."),
            openapi.Parameter('start_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Start date for filtering created_at, format: 'YYYY-MM-DD HH:MM'"),
            openapi.Parameter('end_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="End date for filtering created_at, format: 'YYYY-MM-DD HH:MM'"),
        ]
    )

    def list(self, request, *args, **kwargs):
        return super(ParamLogViewSet, self).list(request, *args, **kwargs)