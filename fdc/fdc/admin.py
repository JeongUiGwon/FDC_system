from django.contrib import admin
from .models import Equipment, Param, Recipe, LotLog, EquipmentState, ParamLog, InterlockLog, ParamHistory, RecipeHistory

admin.site.register(Equipment)
admin.site.register(Param)
admin.site.register(Recipe)
admin.site.register(LotLog)
admin.site.register(EquipmentState)
admin.site.register(ParamLog)
admin.site.register(InterlockLog)
admin.site.register(ParamHistory)
admin.site.register(RecipeHistory)
