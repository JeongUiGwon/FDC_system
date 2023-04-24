from django.urls import path, include
from rest_framework.routers import DefaultRouter
from .views import equipment, param, recipe, lot_log, equipment_state, param_log, interlock_log, param_history, recipe_history
from drf_yasg.views import get_schema_view
from drf_yasg import openapi
from rest_framework.permissions import AllowAny

schema_view = get_schema_view(
    openapi.Info(
        title="API",
        default_version="v1",
        description="API documentation",
    ),
    public=True,
    permission_classes=(AllowAny,),
)

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
    path('swagger/', schema_view.with_ui('swagger', cache_timeout=0), name='schema-swagger-ui'),
    path('redoc/', schema_view.with_ui('redoc', cache_timeout=0), name='schema-redoc'),
]
