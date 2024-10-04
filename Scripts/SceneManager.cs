using Godot;

public partial class SceneManager : Node
{

	public Node CurrentScene { get; set; }// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{

		Viewport root = GetTree().GetRoot();
		CurrentScene = root.GetChild(root.GetChildCount() - 1);
	}

	Viewport GetRoot()
	{
		return GetTree().GetRoot();
	}

	public void LoadScene(string Path, bool bIsAdditive)
	{
		CallDeferred(nameof(DeferredLoadScene), Path, bIsAdditive);
	}
	private void DeferredLoadScene(string Path, bool bIsAdditive)
	{
		if (bIsAdditive)
		{

			LoadSceneAdditive(Path);
		}
		else
		{
			LoadSceneAbsolute(Path);
		}
	}

	private void LoadSceneAdditive(string scenePath)
	{

		var nextScene = (PackedScene)GD.Load(scenePath);
		if (nextScene == null) return;
		LoadInstance(nextScene);
	}

	private void LoadSceneAbsolute(string scenePath)
	{
		//Clear root
		CurrentScene.Free();
		
		PackedScene nextScene = (PackedScene)GD.Load(scenePath);
		if (nextScene == null) return;
		LoadInstance(nextScene);

	}

	private void LoadInstance(PackedScene nextScene)
	{
		//create new scene
		CurrentScene = nextScene.Instantiate();
		//setup new scene
		GetTree().GetRoot().AddChild(CurrentScene);
		GetTree().SetCurrentScene(CurrentScene);
	}



}
