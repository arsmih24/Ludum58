using UnityEngine;
using PlayerSystem;
using LightSystem;

public class Invoker
{
    private PlayerData _playerData;
    private PlayerMovement _playerMovement;
    private PlayerInventory _playerInventory;
    private LightController _lightController;

    public Invoker(PlayerData playerData, PlayerMovement playerMovement, 
                  PlayerInventory playerController, LightController lightController) 
    {
        _playerData = playerData;
        _playerMovement = playerMovement;
        _playerInventory = playerController;
        _lightController = lightController;
    }

    public void InvokeMove(Vector2 dir2, bool sprintHeld) 
    {
        _playerMovement.Move(dir2, _playerData.Rb, _playerData.Sr, _playerData.Anim,
                            _playerData.WalkSpeed, _playerData.SprintSpeed,
                            _playerData.SprintDuration, _playerData.SprintRecharge, sprintHeld);
    }

    public void InvokeCollect() 
    {
        _playerInventory.Collect();
    }

    public void InvokeUvEnable() 
    {
        _lightController.EnableUV();
    }

    public void InvokeUvDisable()
    {
        _lightController.DisableUV();
    }
}
