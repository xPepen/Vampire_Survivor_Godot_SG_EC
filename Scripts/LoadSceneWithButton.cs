using Godot;
using System;

public partial class LoadSceneWithButton : Button
{
	[Export]
	public string ScenePath;

	private SceneManager SceneManager;

	public override void _Ready()
	{
		SceneManager = (SceneManager)GetNode("/root/SceneManager");
		Pressed += OnPressButton;
	}

	private void OnPressButton()
	{
		SceneManager.LoadScene(ScenePath, false);
		//remove event once it processed
		Pressed -= OnPressButton;
	}
}
