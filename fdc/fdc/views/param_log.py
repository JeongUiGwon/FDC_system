from rest_framework import viewsets
from ..models import ParamLog
from ..serializers import ParamLogSerializer

class ParamLogViewSet(viewsets.ModelViewSet):
    serializer_class = ParamLogSerializer

    def get_queryset(self):
        queryset = ParamLog.objects.all
        factory_id = self.request.GET.get('factory_id', None)
        param_value = self.request.GET.get('param_value', None)

        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if param_value:
            queryset = queryset.filter(param_value__icontains=param_value)

        return queryset