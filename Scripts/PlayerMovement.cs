using Godot;

public partial class PlayerMovement : CharacterBody2D // Assurez-vous que cette classe est définie correctement
{
	const float JUMP_VELOCITY = -400.0f;
	[Export] public float Speed = 400.0f;
	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		SingletonManager.Get().GetGameMaster().SetPlayer(this);
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("IA_Left", "IA_Right", "IA_UP", "IA_Down");

		// Flip the sprite
		if (direction.X > 0) // Utilisez 'X' au lieu de 'x'
		{
			animatedSprite.FlipH = false;
		}
		else if (direction.X < 0)
		{
			animatedSprite.FlipH = true;
		}

		// Animation state check
		if (direction.X == 0 && direction.Y == 0)
		{
			if (animatedSprite.Animation != "idle")
			{
				animatedSprite.Play("idle");
			}
		}
		else
		{
			if (animatedSprite.Animation != "walk")
			{
				animatedSprite.Play("walk");
			}
		}

		// Mise à jour de la vélocité
		if (direction.X == 0)
		{
			Velocity = new Vector2(0, Velocity.Y); // Utilisez 'Y' au lieu de 'y'
		}
		else
		{
			Velocity = new Vector2(direction.X * Speed, Velocity.Y); // Utilisez 'X' au lieu de 'x'
		}

		if (direction.Y == 0)
		{
			Velocity = new Vector2(Velocity.X, 0); // Utilisez 'X' au lieu de 'x'
		}
		else
		{
			Velocity = new Vector2(Velocity.X, direction.Y * Speed); // Utilisez 'Y' au lieu de 'y'
		}

		MoveAndSlide();
	}

    public override void _Notification(int what)
    {
        base._Notification(what);
		if(what ==  NotificationExitTree)
		{
			SingletonManager.Get().GetGameMaster().SetPlayer(null);
		}
    }
}


/*
using Godot;
public partial class PlayerMovement : CharacterBody2D
{
	public AnimatedSprite2D animated_sprite;

	[Export]
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
*/
