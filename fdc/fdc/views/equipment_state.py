from rest_framework import viewsets
from ..models import EquipmentState
from ..serializers import EquipmentStateSerializer
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema


class EquipmentStateViewSet(viewsets.ModelViewSet):
    serializer_class = EquipmentStateSerializer

    def get_queryset(self):
        queryset = EquipmentState.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        mode = self.request.GET.get('mode', None)
        status = self.request.GET.get('status', None)

        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if mode:
            queryset = queryset.filter(mode__icontains=mode)
        if status:
            queryset = queryset.filter(status__icontains=status)

        return queryset

    @swagger_auto_schema(
        operation_description="Get a list of EquipmentState objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('factory_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by factory ID."),
            openapi.Parameter('mode', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by mode."),
            openapi.Parameter('status', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by status."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(EquipmentStateViewSet, self).list(request, *args, **kwargs)