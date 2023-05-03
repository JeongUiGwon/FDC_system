from rest_framework import viewsets
from fdc.models import RecipeHistory
from fdc.serializers import RecipeHistorySerializer

class RecipeHistoryViewSet(viewsets.ModelViewSet):
    serializer_class = RecipeHistorySerializer

    def get_queryset(self):
        queryset = RecipeHistory.objects.all()

        action = self.request.GET.get('action', None)

        if action:
            queryset = queryset.filter(action__icontains=action)

        return queryset