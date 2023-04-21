from django.urls import path, include
from rest_framework.routers import DefaultRouter
from .views import equipment, param, recipe, lot_log, equipment_state, param_log, interlock_log, param_history, recipe_history

router = DefaultRouter()
router.register(r'equipment', equipment.EquipmentViewSet)
router.register(r'param', param.ParamViewSet)
router.register(r'recipe', recipe.RecipeViewSet)
router.register(r'lot_log', lot_log.LotLogViewSet)
router.register(r'equipment_state', equipment_state.EquipmentStateViewSet)
router.register(r'param_log', param_log.ParamLogViewSet)
router.register(r'interlock_log', interlock_log.InterlockLogViewSet)
router.register(r'param_history', param_history.ParamHistoryViewSet)
router.register(r'recipe_history', recipe_history.RecipeHistoryViewSet)

urlpatterns = [
    path('', include(router.urls)),
]
