extends CharacterBody2D

@export var Speed = 300.0

func _physics_process(delta) -> void:
	#IA order is important in order to have the correct behavior
	var direction = Input.get_vector("IA_Left", "IA_Right", "IA_UP", "IA_Down")
	
	velocity = direction * Speed;
	move_and_slide()
