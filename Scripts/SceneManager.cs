using Godot;

public partial class SceneManager
{
	private readonly Node Root;
	public SceneManager() { }

	public SceneManager(Node InRoot)
	{
		Root = InRoot;
	}

	public void SetCurrentScene(Node InCurrentScene)
	{
		Root.GetTree().SetCurrentScene(InCurrentScene);
	}
	public Node GetCurrentScene()
	{
		return Root.GetChild(Root.GetChildCount() - 2);
	}

	public void LoadScene(string Path, bool bIsAdditive)
	{
		Node NextScene = ResourceLoader.Load<PackedScene>(Path).Instantiate();
		DeferredLoadScene(NextScene, bIsAdditive);
	}
	private void DeferredLoadScene(Node NextScene, bool bIsAdditive)
	{
		if (bIsAdditive)
		{

			LoadSceneAdditive(NextScene);
		}
		else
		{
			LoadSceneAbsolute(NextScene);
		}
	}

	private void LoadSceneAdditive(Node NextScene)
	{

		LoadInstance(NextScene);
	}

	private void LoadSceneAbsolute(Node NextScene)
	{
		GetCurrentScene().Free();
		LoadInstance(NextScene);

	}

	private void LoadInstance(Node NextScene)
	{
		if (NextScene == null) return;
		Root.AddChild(NextScene);
	}
}
