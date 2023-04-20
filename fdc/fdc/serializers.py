from rest_framework import serializers
from .models import Equipment, Param, Recipe, LotLog, EquipmentState, ParamLog, InterlockLog, ParamHistory, RecipeHistory

class EquipmentSerializer(serializers.ModelSerializer):
    class Meta:
        model = Equipment
        fields = '__all__'

class ParamSerializer(serializers.ModelSerializer):
    class Meta:
        model = Param
        fields = '__all__'

class RecipeSerializer(serializers.ModelSerializer):
    class Meta:
        model = Recipe
        fields = '__all__'

class LotLogSerializer(serializers.ModelSerializer):
    class Meta:
        model = LotLog
        fields = '__all__'

class EquipmentStateSerializer(serializers.ModelSerializer):
    class Meta:
        model = EquipmentState
        fields = '__all__'

class ParamLogSerializer(serializers.ModelSerializer):
    class Meta:
        model = ParamLog
        fields = '__all__'

class InterlockLogSerializer(serializers.ModelSerializer):
    class Meta:
        model = InterlockLog
        fields = '__all__'

class ParamHistorySerializer(serializers.ModelSerializer):
    class Meta:
        model = ParamHistory
        fields = '__all__'

class RecipeHistorySerializer(serializers.ModelSerializer):
    class Meta:
        model = RecipeHistory
        fields = '__all__'
