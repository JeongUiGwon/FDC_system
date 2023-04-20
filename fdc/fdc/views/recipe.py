from rest_framework import viewsets
from fdc.models import Recipe
from fdc.serializers import RecipeSerializer
from rest_framework.views import APIView

class RecipeViewSet(viewsets.ModelViewSet):
    queryset = Recipe.objects.all()
    serializer_class = RecipeSerializer
