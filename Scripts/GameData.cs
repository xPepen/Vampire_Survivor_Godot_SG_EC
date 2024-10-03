using Godot;
using System;

public class GameData 
{
	// Video Settings
	public bool fullScreen = true;
	public bool vsync = true;

	// Dialogue UI Settings
	public float dialogueBG_alpha = 0.4f;
	public int fontSizeMax = 11;

	// Audio Volumes
	public float masterMaxVolume = 1f;
	public float musicMaxVolume = 0.40f;
	public float soundfxMaxVolume = 1f;
	public float voiceMaxVolume = 1f;
	public float femaleMaxVolume = 1f;
	public float maleMaxVolume = 1f;

	// Default Audio Volumes (constants)
	public const float default_masterMaxVolume = 1f;
	public const float default_musicMaxVolume = 0.40f;
	public const float default_soundfxMaxVolume = 1f;
	public const float default_voiceMaxVolume = 1f;
	public const float default_femaleMaxVolume = 1f;
	public const float default_maleMaxVolume = 1f;

	// Méthode pour réinitialiser les volumes aux valeurs par défaut
	public void ResetToDefaults()
	{
		masterMaxVolume = default_masterMaxVolume;
		musicMaxVolume = default_musicMaxVolume;
		soundfxMaxVolume = default_soundfxMaxVolume;
		voiceMaxVolume = default_voiceMaxVolume;
		femaleMaxVolume = default_femaleMaxVolume;
		maleMaxVolume = default_maleMaxVolume;
	}
}
