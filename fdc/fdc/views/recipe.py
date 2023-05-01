from rest_framework import viewsets
from fdc.models import Recipe
from fdc.serializers import RecipeSerializer

class RecipeViewSet(viewsets.ModelViewSet):
    queryset = Recipe.objects.all()
    serializer_class = RecipeSerializer
