using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class SingletonManager : SceneTree
{

    private static Dictionary<Type, Node> SingletonInstances;

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

    private T GetSingletonInstance<T>() where T : Node, new()
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
        SingletonInstances = new Dictionary<Type, Node>();


        Node SceneManager = this.GetRoot().GetNode("SceneManager");
        SingletonInstances.Add(typeof(SceneManager), SceneManager);

        Node GameMaster = this.GetRoot().GetNode("GameMaster");
        SingletonInstances.Add(typeof(SceneManager), GameMaster);

        GD.Print($" SingletonManager : Singleton are initialized");
    }

}
