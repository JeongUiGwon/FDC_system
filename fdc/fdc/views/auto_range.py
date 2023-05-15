from rest_framework import viewsets, status
from rest_framework.response import Response
from ..models import AutoRange, Param, Recipe, ParamLog
from ..serializers import AutoRangeSerializer
from datetime import datetime
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema
from django.db.models import Avg, StdDev


class AutoRangeViewSet(viewsets.ModelViewSet):
    serializer_class = AutoRangeSerializer
    queryset = AutoRange.objects.all()

    def create(self, request, *args, **kwargs):
        param_id = request.data.get('param')
        if AutoRange.objects.filter(param_id=param_id).exists():
            return Response({"error": "AutoRange for this param already exists."}, status=400)

        serializer = self.get_serializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        self.perform_create(serializer)

        if serializer.validated_data.get('is_active'):
            param_id = serializer.validated_data.get('param').param_id
            auto_range = AutoRange.objects.get(id=serializer.data['id'])  # Add this line
            self.apply_auto_range(param_id, auto_range)

        headers = self.get_success_headers(serializer.data)
        return Response(serializer.data, status=status.HTTP_201_CREATED, headers=headers)

    def update(self, request, *args, **kwargs):
        partial = kwargs.pop('partial', False)
        instance = self.get_object()
        serializer = self.get_serializer(instance, data=request.data, partial=partial)
        serializer.is_valid(raise_exception=True)
        self.perform_update(serializer)

        if serializer.validated_data.get('is_active'):
            param_id = serializer.validated_data.get('param').param_id
            auto_range = AutoRange.objects.get(id=serializer.data['id'])  # Add this line
            self.apply_auto_range(param_id, auto_range)

        return Response(serializer.data)

    @staticmethod
    def apply_auto_range(param_id, auto_range):  # Add auto_range parameter
        recipes = Recipe.objects.filter(param__param_id=param_id)
        print(f'recipes: {recipes}')
        for recipe in recipes:
            print(f'recipe: {recipe}')
            param_logs = ParamLog.objects.filter(recipe_id=recipe)
            print(f'param_logs: {param_logs}')

            # 데이터가 없다면 함수 종료
            if not param_logs.exists():
                return
            # ParamLog 데이터에서 param_value의 평균과 표준편차를 계산\
            try:
                mean = param_logs.aggregate(Avg('param_value'))['param_value__avg']
                std_dev = param_logs.aggregate(StdDev('param_value'))['param_value__stddev']
                print(f'mean:{mean}, std_dev: {std_dev}')
                if auto_range.type == 'percent':
                    lower_bound = mean - (mean * auto_range.lsl_weight / 100)
                    upper_bound = mean + (mean * auto_range.usl_weight / 100)
                elif auto_range.type == 'sigma':
                    lower_bound = mean - auto_range.lsl_weight * std_dev
                    upper_bound = mean + auto_range.usl_weight * std_dev
                else:
                    return
            except Exception as e:
                print(f'error in cal {e}')

            print(recipe.recipe_id)
            # 해당 recipe 가져옴
            recipe = Recipe.objects.get(recipe_id=recipe.recipe_id)
            print(recipe)
            # USL, LSL 업데이트
            print(f'lsl: {recipe.lsl} -> {lower_bound}')
            print(f'usl: {recipe.usl} -> {upper_bound}')

            auto_range.prev_lsl = recipe.lsl
            auto_range.prev_usl = recipe.usl
            auto_range.save()

            recipe.lsl = lower_bound
            recipe.usl = upper_bound
            recipe.save()

    def get_queryset(self):
        queryset = AutoRange.objects.all()

        param_id = self.request.GET.get('recipe_id', None)
        min_range = self.request.GET.get('min_range', None)
        max_range = self.request.GET.get('max_range', None)
        interval = self.request.GET.get('interval', None)
        type = self.request.GET.get('type', None)
        start_date = self.request.GET.get('start_date', None)
        end_date = self.request.GET.get('end_date', None)

        if param_id:
            recipe_id_list = param_id.split(',')
            queryset = queryset.filter(recipe__recipe_id__in=recipe_id_list)
        if min_range:
            queryset = queryset.filter(min_range__gte=min_range)
        if max_range:
            queryset = queryset.filter(max_range__lte=max_range)
        if interval:
            queryset = queryset.filter(interval__gte=interval)
        if type:
            queryset = queryset.filter(type__icontains=type)
        if start_date and end_date:
            start_date_obj = datetime.strptime(start_date, '%Y-%m-%d %H:%M')
            end_date_obj = datetime.strptime(end_date, '%Y-%m-%d %H:%M')
            queryset = queryset.filter(created_at__range=(start_date_obj, end_date_obj))

        return queryset

    @swagger_auto_schema(
        operation_description="Get a list of AutoRange objects filtered by the provided parameters.",
        manual_parameters=[
            openapi.Parameter('param_id', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Comma-separated list of param IDs to filter by."),
            openapi.Parameter('min_range', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Minimum range to filter by."),
            openapi.Parameter('max_range', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Maximum range to filter by."),
            openapi.Parameter('interval', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Interval to filter by."),
            openapi.Parameter('type', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Type to filter by."),
            openapi.Parameter('start_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by start date (format: YYYY-MM-DD HH:MM)."),
            openapi.Parameter('end_date', openapi.IN_QUERY, type=openapi.TYPE_STRING,
                              description="Filter by end date (format: YYYY-MM-DD HH:MM)."),
        ]
    )
    def list(self, request, *args, **kwargs):
        return super(AutoRangeViewSet, self).list(request, *args, **kwargs)
