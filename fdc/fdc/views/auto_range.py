from rest_framework import viewsets, status
from rest_framework.response import Response
from ..models import AutoRange
from ..serializers import AutoRangeSerializer
from datetime import datetime
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema
import json
from django_celery_beat.models import PeriodicTask, IntervalSchedule

from ..celery import app
from ..tasks import apply_auto_range_task


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
            auto_range = AutoRange.objects.get(id=serializer.data['id'])
            # countdown = auto_range.interval * 60 * 60
            countdown = 10
            task = apply_auto_range_task.apply_async((auto_range.id,))
            auto_range.task_id = task.id
            auto_range.save()

            interval, created = IntervalSchedule.objects.get_or_create(
                every=countdown,
                period=IntervalSchedule.SECONDS,
            )
            print(f'interval {interval}')
            periodic_task = PeriodicTask.objects.create(
                name=f"auto_range_task_{auto_range.id}",
                task="fdc.fdc.apply_auto_range_task",
                interval=interval,
                args=json.dumps([auto_range.id])
            )
            print(f'periodic_task {periodic_task}')
            periodic_task.save()

        headers = self.get_success_headers(serializer.data)
        return Response(serializer.data, status=status.HTTP_201_CREATED, headers=headers)

    def update(self, request, *args, **kwargs):
        partial = kwargs.pop('partial', False)
        instance = self.get_object()
        serializer = self.get_serializer(instance, data=request.data, partial=partial)
        serializer.is_valid(raise_exception=True)
        self.perform_update(serializer)

        if serializer.validated_data.get('is_active'):
            auto_range = AutoRange.objects.get(id=serializer.data['id'])
            # Cancel the previous task if it exists
            if auto_range.task_id:
                app.control.revoke(auto_range.task_id, terminate=True)

            # Schedule the new task
            countdown = auto_range.interval * 60 * 60
            task = apply_auto_range_task.apply_async((auto_range.id,))
            auto_range.task_id = task.id
            auto_range.save()

            periodic_task = PeriodicTask.objects.create(
                name=f"auto_range_task_{auto_range.id}",
                task="fdc.fdc.apply_auto_range_task",
                interval=IntervalSchedule.objects.get(every=countdown, period=IntervalSchedule.SECONDS),
                args=json.dumps([auto_range.id])
            )
            periodic_task.save()

        return Response(serializer.data)

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
