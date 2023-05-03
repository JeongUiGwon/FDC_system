from rest_framework import viewsets
from ..models import ParamHistory
from ..serializers import ParamHistorySerializer

class ParamHistoryViewSet(viewsets.ModelViewSet):
    serializer_class = ParamHistorySerializer

    def get_queryset(self):
        queryset = ParamHistory.objects.all()

        action = self.request.GET.get('action', None)
        param_name = self.request.GET.get('param_name', None)

        if action:
            queryset = queryset.filter(action__icontains=action)
        if param_name:
            queryset = queryset.filter(param_name__icontains=param_name)

        return queryset