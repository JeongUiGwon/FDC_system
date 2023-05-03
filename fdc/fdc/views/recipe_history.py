from rest_framework import viewsets
from ..models import RecipeHistory
from ..serializers import RecipeHistorySerializer

class RecipeHistoryViewSet(viewsets.ModelViewSet):
    queryset = RecipeHistory.objects.all()
    serializer_class = RecipeHistorySerializer
