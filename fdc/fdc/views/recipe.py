from rest_framework import viewsets
from ..models import Recipe
from ..serializers import RecipeSerializer
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema


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

    @swagger_auto_schema(
        operation_description="Get a list of Recipe objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('recipe_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by recipe ID."),
            openapi.Parameter('recipe_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by recipe name."),
            openapi.Parameter('recipe_use', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by recipe use."),
            openapi.Parameter('creator_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by creator name."),
            openapi.Parameter('equipment_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by equipment name."),
            openapi.Parameter('param_name', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by parameter name."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(RecipeViewSet, self).list(request, *args, **kwargs)