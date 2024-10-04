using Godot;
using System;

public partial class LoadSceneWithButton : Button
{
	[Export]
	public string ScenePath;


	public override void _Ready()
	{
		Pressed += OnPressButton;
	}

	private void OnPressButton()
	{
		SingletonManager.Get().GetSceneManager().LoadScene(ScenePath, false);
		//remove event once it processed
		Pressed -= OnPressButton;
	}
}
