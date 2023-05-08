from datetime import datetime
from rest_framework import viewsets
from ..models import RecipeHistory
from ..serializers import RecipeHistorySerializer
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema

class RecipeHistoryViewSet(viewsets.ModelViewSet):
    serializer_class = RecipeHistorySerializer

    def get_queryset(self):
        queryset = RecipeHistory.objects.all()

        action = self.request.GET.get('action', None)
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)

        if action:
            queryset = queryset.filter(action__icontains=action)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))

        return queryset

    @swagger_auto_schema(
        operation_description="Get a list of RecipeHistory objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('action', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by action."),
            openapi.Parameter('start_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by start date (format: YYYY-MM-DD HH:MM)."),
            openapi.Parameter('end_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by end date (format: YYYY-MM-DD HH:MM)."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(RecipeHistoryViewSet, self).list(request, *args, **kwargs)