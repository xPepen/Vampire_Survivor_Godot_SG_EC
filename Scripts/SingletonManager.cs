using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class SingletonManager : SceneTree
{

    private static Dictionary<Type, object> SingletonInstances;

    private SingletonManager()
    {
        _instance = this;
    }
    private static SingletonManager _instance;


    public static SingletonManager Get()
    {
        if (_instance == null)
        {
            _instance = new SingletonManager();
        }
        return _instance;
    }

    public T GetSingletonInstance<T>() where T : class, new()
    {
        if (SingletonInstances.ContainsKey(typeof(T)))
        {
            return (T)SingletonInstances[typeof(T)];
        }
        else
        {
            T instance = new T();
            SingletonInstances.Add(typeof(T), instance);
            return instance;
        }
    }
    public SceneManager GetSceneManager()
    {
        return GetSingletonInstance<SceneManager>();
    }

    public GameMaster GetGameMaster()
    {
        return GetSingletonInstance<GameMaster>();
    }

    public override void _Initialize()
    {
        SingletonInstances = new Dictionary<Type, object>();

        //Get access to the root
        Node Root = this.Root.GetChild(this.Root.GetChildCount() - 1);


        object SceneManager = new SceneManager(Root);
        SingletonInstances.Add(typeof(SceneManager), SceneManager);

        object SaveManager = new GameMaster();
        SingletonInstances.Add(typeof(GameMaster), SaveManager);

        object PlayerController = new PlayerController();
        SingletonInstances.Add(typeof(PlayerController), PlayerController);


        GD.Print($" SingletonManager : Singleton are initialized");
    }

}
