from rest_framework import viewsets
from fdc.models import Param
from fdc.serializers import ParamSerializer

class ParamViewSet(viewsets.ModelViewSet):
    queryset = Param.objects.all()
    serializer_class = ParamSerializer
