using Godot;
using System;

public partial class Save : Button
{
	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		GD.Print("Saving pressed"); 
		SingletonManager.Get().GetGameMaster().SaveGame();
	}
}
