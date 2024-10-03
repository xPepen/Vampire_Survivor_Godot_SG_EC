using Godot;
using System;

public class PlayerData
{
	public string saveFileVersion = GameMaster.gameVersion;
	public int checkpoint = 0;
	public int overworldCheckpoint = 0;
	public string savedScene = default;

	// Exemple : position du joueur
	public Vector3 playerPosition = new Vector3();

	// Dictionnaire d'exemple
	public Godot.Collections.Dictionary<string, int> sampleDictionary = new Godot.Collections.Dictionary<string, int>();

	public void init()
	{
		//mettre les donnees quon veut sauvegarder ici
		sampleDictionary.Add("zero", 0);
		sampleDictionary.Add("one", 1);
		sampleDictionary.Add("two", 2);
	}
}
