extends CharacterBody2D


const JUMP_VELOCITY = -400.0
@export var Speed = 400.0
@onready var animated_sprite = $AnimatedSprite2D

func _physics_process(delta) -> void:
	#IA order is important in order to have the correct behavior
	var direction = Input.get_vector("IA_Left", "IA_Right", "IA_UP", "IA_Down")
	# Debug direction
	print("Direction: ", direction)
	
	#Flip the sprite
	if direction.x > 0:
		animated_sprite.flip_h = false
	elif direction.x < 0:
		animated_sprite.flip_h = true 
		
	# Animation state check
	if direction.x == 0 and direction.y == 0:
		if animated_sprite.animation != "idle":
			print("Switching to idle")
			animated_sprite.play("idle")
	else:
		if animated_sprite.animation != "walk":
			print("Switching to walk")
			animated_sprite.play("walk")
			
	if direction.x == 0:
		velocity.x = 0
	else:
		velocity.x = direction.x * Speed

	if direction.y == 0:
		velocity.y = 0
	else:
		velocity.y = direction.y * Speed

	move_and_slide()
