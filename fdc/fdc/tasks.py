from celery import shared_task
from django.db.models import Avg, StdDev
from .models import AutoRange, Recipe, ParamLog


@shared_task
def apply_auto_range_task(auto_range_id):
    print('START apply_auto_range_task..')
    auto_range = AutoRange.objects.get(id=auto_range_id)
    param_id = auto_range.param_id

    recipes = Recipe.objects.filter(param__param_id=param_id)
    # print(f'recipes: {recipes}')
    for recipe in recipes:
        # print(f'recipe: {recipe}')
        param_logs = ParamLog.objects.filter(recipe_id=recipe)
        # print(f'param_logs: {param_logs}')

        # 데이터가 없다면 함수 종료
        if not param_logs.exists():
            return
        # ParamLog 데이터에서 param_value의 평균과 표준편차를 계산
        try:
            mean = param_logs.aggregate(Avg('param_value'))['param_value__avg']
            std_dev = param_logs.aggregate(StdDev('param_value'))['param_value__stddev']
            print(f'mean:{mean}, std_dev: {std_dev}')
            if auto_range.type == 'percent':
                lower_bound = mean - (mean * auto_range.min_range / 100)
                upper_bound = mean + (mean * auto_range.max_range / 100)
            elif auto_range.type == 'sigma':
                lower_bound = mean - auto_range.min_range * std_dev
                upper_bound = mean + auto_range.max_range * std_dev
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
