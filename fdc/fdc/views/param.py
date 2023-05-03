from rest_framework import viewsets
from ..models import Param
from ..serializers import ParamSerializer

class ParamViewSet(viewsets.ModelViewSet):
    queryset = Param.objects.all()
    serializer_class = ParamSerializer
