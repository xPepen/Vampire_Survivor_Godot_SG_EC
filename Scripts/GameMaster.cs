using Godot;
using System;

public partial class GameMaster : Node
{
	public static string gameVersion = "Version 1.0";

	public static PlayerData playerData = new PlayerData();

	public static GameData gameData = new GameData();
	
	bool InGame;
	string SaveFilePath = "user://savegame.dat"; 

	public override void _Ready()
	{
		
		GD.Print("Gamemaster Ready!");
		
		playerData.init();
		
		Check(SaveFilePath);
		
		string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
		GD.Print(jsonString); 
	}

public void Check(string SaveFilePath){
 using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read))
		{
			if (file.GetLength() > 0)
			{
				GD.Print("Le fichier contient des données.");
				LoadGame();
			}
			else
			{
				GD.Print("Le fichier est vide.");
				SaveGame();
			}
		}
}

	public void SaveGame()
	{
		var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write);
			string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
			file.StoreString(jsonString); 
			file.Close();
			GD.Print("Game saved!");
			InGame = true;
		
	}

	public void LoadGame()
	{
		var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read);
		if (FileAccess.FileExists(SaveFilePath))
		{
			
				string jsonString = file.GetAsText(); 
				playerData = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerData>(jsonString);
				file.Close();
				GD.Print("Game loaded!");
		}
		else
		{
			GD.Print("No save file found. Starting new game.");
			InGame = false; 
		}
	}

	public override void _Process(double delta)
	{
	}
}
