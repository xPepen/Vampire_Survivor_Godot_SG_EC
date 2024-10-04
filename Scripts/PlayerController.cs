using System.Reflection.Metadata.Ecma335;
using Godot;

public partial class PlayerController
{
    PlayerMovement PlayerInstance;


    public PlayerController() { }
    public PlayerController(PlayerMovement Instance) { SetNewController(Instance); }


    public PlayerMovement GetController() => PlayerInstance;

    public void SetNewController(PlayerMovement NewController)
    {
        PlayerInstance = NewController;
    }

    public void ClearController()
    {
        PlayerInstance = null;
    }

}
