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
        extra_kwargs = {'equipment_name': {'required': False},
                        'cause_equip_name': {'required': False}}

        read_only_fields = ('equipment_name', 'cause_equip_name')
    def create(self, validated_data):
        equipment = Equipment.objects.get(pk=validated_data['equipment_id'].id)
        validated_data['equipment_name'] = equipment.equipment_name
        validated_data['cause_equip_id'] = equipment.equipment_id
        validated_data['cause_equip_name'] = equipment.equipment_name
        return super(InterlockLogSerializer, self).create(validated_data)

class ParamHistorySerializer(serializers.ModelSerializer):
    class Meta:
        model = ParamHistory
        fields = '__all__'
        read_only_fields = ['param_name']

class RecipeHistorySerializer(serializers.ModelSerializer):
    class Meta:
        model = RecipeHistory
        fields = '__all__'
