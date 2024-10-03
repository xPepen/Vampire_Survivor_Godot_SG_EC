using Godot;
using System;

public partial class GameMaster : Node
{
	public static string gameVersion = "Version 1.0";
	
	public static PlayerData playerData = new PlayerData();
	
	public static GameData gameData = new GameData();
	
	public override void _Ready()
	{
		GD.Print("Gamemaster Ready!");
		
		playerData.init();
		
		string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);

		GD.Print(jsonString);	
	}

	public override void _Process(double delta)
	{
	}
}
