using Godot;
using System;
using Newtonsoft.Json;

public partial class GameMaster : Node
{
	public static GameMaster Instance { get; private set; }
	private const string SaveFilePath = "user://savegame.json";

	private PlayerData playerData;

	public override void _Ready()
	{
		Instance = this; 
	}

	private PlayerMovement GetPlayer(Node currentNode = null)
	{
		if (currentNode == null)
			currentNode = GetTree().Root;

		// Vérifie si ce nœud est le joueur
		if (currentNode is PlayerMovement player)
			return player;

		// Parcourt tous les enfants de ce nœud
		foreach (Node child in currentNode.GetChildren())
		{
			var foundPlayer = GetPlayer(child);
			if (foundPlayer != null)
				return foundPlayer;
		}

		return null; 
	}

	public void SaveGame()
	{
		GD.Print("Tentative de récupération du nœud joueur...");

		PlayerMovement player = GetPlayer(); // Utiliser la méthode GetPlayer pour obtenir le nœud Player

		if (player != null)
		{
			GD.Print("Joueur récupéré : ", player);
			GD.Print("Position actuelle du joueur : ", player.Position);
			
			playerData = new PlayerData
			{
				Message = "Loading Réussi!",
				Position = player.Position
			};

			using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write))
			{
				string jsonString = JsonConvert.SerializeObject(playerData);
				file.StoreString(jsonString);
				GD.Print("Sauvegarde effectuée à la position : ", player.Position);
			}
		}
		else
		{
			GD.PrintErr("Joueur non trouvé !");
		}
	}

	public void LoadGame()
	{
		GD.Print("Loading..."); 
		
		if (FileAccess.FileExists(SaveFilePath))
		{
			using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Read))
			{
				string jsonString = file.GetAsText();
				playerData = JsonConvert.DeserializeObject<PlayerData>(jsonString); 
				
				GD.Print("Game loaded! PlayerData: ", JsonConvert.SerializeObject(playerData));

				PlayerMovement player = GetPlayer(); // Obtenez le joueur de la même manière
				if (player != null)
				{
					player.Position = playerData.Position; 
				}
			}
		}
		else
		{
			GD.Print("No save file found. Starting new game.");
			SaveGame(); 
		}
	}
}

public class PlayerData
{
	public string Message { get; set; }
	public Vector2 Position { get; set; }
}
