using Godot;
using System;

public partial class CustomLabel : Label
{

	PlayerController PlayerInstance;
	public override void _Ready()
	{
		PlayerInstance = SingletonManager.Get().GetSingletonInstance<PlayerController>();
	}

	public override void _Process(double delta)
	{
		this.Text = PlayerInstance.GetController().Position.Round().ToString();
	}
}
