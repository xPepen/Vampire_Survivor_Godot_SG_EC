using Godot;

public partial class Load : Button
{
	public override void _Ready()
	{
		
		Pressed += OnPressButton;
	}

	private void OnPressButton()
	{
		
		GD.Print("Bouton Load pressé !");
		GameMaster.Instance.LoadGame();
		
	}
}
