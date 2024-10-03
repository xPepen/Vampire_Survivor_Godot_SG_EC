using Godot;
using System;

public partial class GameMaster : Node
{
	public static string gameVersion = "Version 1.0";
	public static PlayerData playerData = new PlayerData();
	public string SaveFilePath = "user://savegame.dat"; 

	public Label positionLabel;

public override void _Ready()
{
	positionLabel = GetNode<Label>("PositionLabel");

	Button saveButton = GetNode<Button>("Control/SaveButton"); // Remplacez par le bon chemin
	saveButton.Pressed += OnSaveButtonPressed; // Connexion du signal de sauvegarde

	Button loadButton = GetNode<Button>("Control/LoadButton"); // Remplacez par le bon chemin
	loadButton.Pressed += OnLoadButtonPressed; // Connexion du signal de chargement
}


	public override void _Process(double delta)
	{
		
		var player = GetNode<CharacterBody2D>("Game/Player"); 
		positionLabel.Text = $"Position: {player.GlobalPosition}"; 
	}


	public void OnSaveButtonPressed()
	{
		var player = GetNode<CharacterBody2D>("Game/Player"); 
		GD.Print("save button fonctionne");

		
		playerData.playerPosition = player.GlobalPosition;

		
		SaveGame();
		GD.Print("Player position saved: ", playerData.playerPosition);
	}

	
	public void OnLoadButtonPressed()
	{
		Check(SaveFilePath);
		GD.Print("load button fonctionne");
		var player = GetNode<CharacterBody2D>("Game/Player"); 
		player.GlobalPosition = playerData.playerPosition;

		GD.Print("Player position loaded: ", playerData.playerPosition);
	}


	public void Check(string saveFilePath)
	{
		if (FileAccess.FileExists(saveFilePath))
		{
			using (var file = FileAccess.Open(saveFilePath, FileAccess.ModeFlags.Read))
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
		else
		{
			GD.Print("No save file found. Starting new game.");
			SaveGame(); // Crée un nouveau fichier de sauvegarde
		}
	}

	// Sauvegarde les données dans le fichier
	public void SaveGame()
	{
		using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write))
		{
			string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
			file.StoreString(jsonString); 
			GD.Print("Game saved!");
		}
	}

	// Charge les données à partir du fichier
	public void LoadGame()
	{
		if (FileAccess.FileExists(SaveFilePath))
		{
			using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read))
			{
				string jsonString = file.GetAsText(); 
				playerData = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerData>(jsonString);
				GD.Print("Game loaded! PlayerData: ", Newtonsoft.Json.JsonConvert.SerializeObject(playerData));
			}
		}
		else
		{
			GD.Print("No save file found. Starting new game.");
		}
	}


}
