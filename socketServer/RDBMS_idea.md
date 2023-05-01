설비에서 FDC로 보내줘야 하는 데이터 목록

created_at (datetime6)
data_value (double)
equipment_id (varchar50)
equipment_name (varchar50)
lot_id (int)
param_id (varchar50)
recipe_id (varchar50)
equipment_mode (varchar15) (ex. auto/manual)
equipment_status (varchar15) (ex. processing/idle/pause)

-------------------------------------------------
FDC에서 찾아야 하는 데이터 목록

- interlock_equipment_id
: equipment table에 equipment_id로 들어가서 interlock_id

- interlock_equipment_name
: pass

- usl
: recipe table에 recipe_id로 들어가서 usl

- lsl
: recipe table에 recipe_id로 들어가서 lsl

- interlock_type
: data_value를 usl, lsl과 비교해서 해당되는 값
: recipe table에 recipe_id로 들어가서 lsl/usl_interlock_action

- out_count (int)
: interlock_log table에 interlock_equipment_id 같고, param_id 같고, recipe_id 같으면 1씩 증가

-------------------------------------------------
FDC에서 param_log_test table에 넣어줘야 하는 데이터 목록

- created_at
- data_value
- equipment_id
- param_id
- recipe_id

-------------------------------------------------
FDC에서 interlock_log_test table에 넣어줘야 하는 데이터 목록

- created_at
- interlock_type
- upper_limit
- data_value
- lower_limit
- cause_equip_id
- cause_equip_name
- equipment_id
- equipment_name?
- lot_id
- param_id
- recipe_id
- out_count