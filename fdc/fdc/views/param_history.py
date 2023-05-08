from rest_framework import viewsets
from ..models import ParamHistory
from ..serializers import ParamHistorySerializer
from datetime import datetime
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema

class ParamHistoryViewSet(viewsets.ModelViewSet):
    serializer_class = ParamHistorySerializer

    def get_queryset(self):
        queryset = ParamHistory.objects.all()

        action = self.request.GET.get('action', None)
        param_name = self.request.GET.get('param_name', None)
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)
        if action:
            queryset = queryset.filter(action__icontains=action)
        if param_name:
            queryset = queryset.filter(param_name__icontains=param_name)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))
        return queryset

    @swagger_auto_schema(
        operation_description="Get a list of ParamHistory objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('action', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by action."),
            openapi.Parameter('param_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by parameter name."),
            openapi.Parameter('start_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by start date (format: YYYY-MM-DD HH:MM)."),
            openapi.Parameter('end_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by end date (format: YYYY-MM-DD HH:MM)."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(ParamHistoryViewSet, self).list(request, *args, **kwargs)
