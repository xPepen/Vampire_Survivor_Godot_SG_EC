using Godot;
using System;


public partial class PlayerPositionIndicator : Node2D
{
	private PlayerMovement player; // Référence au joueur
	private Label positionLabel; // Référence au Label

public override void _Ready()
{
	player = GetParent().GetNode<PlayerMovement>("Player"); 
	positionLabel = GetNode<Label>("Label"); 
	
	GD.Print("Player Position Indicator Initialized");
	if (player != null)
	{
		GD.Print("Player found: ", player.Position);
	}
	else
	{
		GD.Print("Player not found.");
	}
}

public override void _Process(double delta)
{
	if (player != null)
	{
		Position = player.Position; 
		positionLabel.Text = $"Position: {player.Position}";
		GD.Print($"Current Player Position: {player.Position}");
	}
	else
	{
		GD.Print("Player reference is null.");
	}
}


}
