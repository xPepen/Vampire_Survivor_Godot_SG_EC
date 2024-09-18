using Godot;

public partial class PlayerMovement : CharacterBody2D
{
	public AnimatedSprite2D animated_sprite;
	public float Speed = 300;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animated_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// order is important in order to have the correct behavior
		var direction = Input.GetVector("IA_Left", "IA_Right", "IA_UP", "IA_Down");

		Velocity = direction * Speed;
		animated_sprite.FlipH = direction.X < 0;
		if (Velocity == Vector2.Zero)
		{
			animated_sprite.Play("idle");
		}
		else
		{
			animated_sprite.Play("walk");
		}
		MoveAndSlide();

	}
}