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

	public void SaveGame()
{
	GD.Print("Tentative de récupération du nœud joueur...");

	AnimatedSprite2D player;
	try
	{
		player = GetNode<AnimatedSprite2D>("Player/AnimatedSprite2D"); 
		GD.Print("Joueur récupéré : ", player);
	}
	catch (Exception e)
	{
		GD.PrintErr("Erreur lors de la récupération du joueur : ", e);
		return; 
	}

	playerData = new PlayerData
	{
		Message = "Ceci est une sauvegarde test.",
		Position = player.Position
	};

	using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write))
	{
		string jsonString = JsonConvert.SerializeObject(playerData);
		file.StoreString(jsonString);
		GD.Print("Sauvegarde effectuée avec succès !");
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
				
				// Imprimer le message contenu dans playerData
				GD.Print("Game loaded! PlayerData: ", JsonConvert.SerializeObject(playerData));

				// Mettez à jour la position du joueur
				AnimatedSprite2D player = GetNode<AnimatedSprite2D>("Game/Player"); // Remplacez "Player" par le chemin correct
				player.Position = playerData.Position; // Mettez à jour la position
			}
		}
		else
		{
			GD.Print("No save file found. Starting new game.");
			SaveGame(); // Optionnel : sauvegarde un nouveau jeu si aucun fichier n'est trouvé
		}
	}
}


// Assurez-vous que cette classe est définie quelque part dans votre projet
public class PlayerData
{
	public string Message { get; set; }
	public Vector2 Position { get; set; } // Utilisez Vector3 si vous êtes en 3D
	// Ajoutez d'autres propriétés nécessaires ici
}



/*	
using Godot;
using System;

public partial class GameMaster : Node
{
	public static string gameVersion = "Version 1.0";
	public static PlayerData playerData = new PlayerData();
	public string SaveFilePath = "user://savegame.dat"; 

	public override void _Ready()
	{
	
	}

	public override void _Process(double delta)
	{

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
					LoadGame(); // Charger les données
				}
				else
				{
					GD.Print("Le fichier est vide.");
					SaveGame(); // Crée un nouveau fichier de sauvegarde
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
		  GD.Print("La sauvegarde du jeu est en cours...");
	
		using (var file = FileAccess.Open(SaveFilePath, FileAccess.ModeFlags.Write))
		{
			string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
			file.StoreString(jsonString); 
			GD.Print("Sauvegarder!");
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
			SaveGame();
		}
	}
}
*/
