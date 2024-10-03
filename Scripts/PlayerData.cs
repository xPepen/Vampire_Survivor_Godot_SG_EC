using Godot;
using System;

public class PlayerData
{
	public string saveFileVersion = GameMaster.gameVersion;
	public int checkpoint = 0;
	public int overworldCheckpoint = 0;
	public string savedScene = default;

	// Changer Vector3 en Vector2
	public Vector2 playerPosition = new Vector2(); 

	public void init()
	{
	}
}
