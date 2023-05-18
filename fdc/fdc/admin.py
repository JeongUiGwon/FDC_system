from django.contrib import admin
from .models import Equipment, Param, Recipe, LotLog, EquipmentState, ParamLog, InterlockLog, ParamHistory, \
    RecipeHistory


class ParamAdmin(admin.ModelAdmin):
    list_display = (
    'param_id', 'equipment', 'param_name', 'param_level', 'param_state', 'creator_name', 'created_at', 'modifier_name',
    'updated_at', 'get_equipment_name')

    def get_equipment_name(self, obj):
        return obj.equipment.equipment_name

    get_equipment_name.short_description = 'Equipment Name'


class RecipeAdmin(admin.ModelAdmin):
    list_display = ()


admin.site.register(Equipment)
admin.site.register(Param)
admin.site.register(Recipe)
admin.site.register(LotLog)
admin.site.register(EquipmentState)
admin.site.register(ParamLog)
admin.site.register(InterlockLog)
admin.site.register(ParamHistory)
admin.site.register(RecipeHistory)
