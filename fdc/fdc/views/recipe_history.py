from rest_framework import viewsets
from fdc.models import RecipeHistory
from fdc.serializers import RecipeHistorySerializer

class RecipeHistoryViewSet(viewsets.ModelViewSet):
    queryset = RecipeHistory.objects.all()
    serializer_class = RecipeHistorySerializer
