from rest_framework import viewsets
from fdc.models import InterlockLog
from fdc.serializers import InterlockLogSerializer

class InterlockLogViewSet(viewsets.ModelViewSet):
    serializer_class = InterlockLogSerializer

    def get_queryset(self):
        queryset = InterlockLog.objects.all()

        factory_id = self.request.GET.get('factory_id', None)
        interlock_type = self.request.GET.get('interlock_type', None)
        out_count = self.request.GET.get('out_count', None)

        if factory_id:
            queryset = queryset.filter(factory_id__icontains=factory_id)
        if interlock_type:
            queryset = queryset.filter(interlock_type__icontains=interlock_type)
        if out_count:
            queryset = queryset.filter(out_count__icontains=out_count)

        return queryset
