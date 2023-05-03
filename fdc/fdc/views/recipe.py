from rest_framework import viewsets
from fdc.models import Recipe
from fdc.serializers import RecipeSerializer

class RecipeViewSet(viewsets.ModelViewSet):
    serializer_class = RecipeSerializer

    def get_queryset(self):
        queryset = Recipe.objects.all()

        recipe_id = self.request.GET.get('recipe_id', None)
        recipe_name = self.request.GET.get('recipe_name', None)
        recipe_use = self.request.GET.get('recipe_use', None)
        creator_name = self.request.GET.get('creator_name', None)
        equipment_name = self.request.GET.get('equipment_name', None) # 쿼리 파라미터에서 equipment_name 가져오기
        param_name = self.request.GET.get('param_name', None) # 쿼리 파라미터에서 param_name 가져오기

        if recipe_id:
            queryset = queryset.filter(recipe_id__icontains=recipe_id)
        if recipe_name:
            queryset = queryset.filter(recipe_name__icontains=recipe_name)
        if recipe_use:
            queryset = queryset.filter(recipe_use__icontains=recipe_use)
        if creator_name:
            queryset = queryset.filter(creator_name__icontains=creator_name)
        if equipment_name:
            queryset = queryset.filter(equipment__equipment_name__icontains=equipment_name)  # equipment_name으로 필터링
        if param_name:
            queryset = queryset.filter(param__param_name__icontains=param_name)  # param_name으로 필터링

        return queryset
