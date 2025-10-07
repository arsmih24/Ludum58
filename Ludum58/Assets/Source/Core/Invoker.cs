using UnityEngine;
using PlayerSystem;
using LightSystem;
using UiSystem;

public class Invoker
{
    private PlayerData _playerData;
    private PlayerMovement _playerMovement;
    private PlayerController _playerController;
    private LightController _lightController;
    private UiController _uiController;

    public Invoker(PlayerData playerData, PlayerMovement playerMovement, 
                  PlayerController playerController, LightController lightController, UiController uiController) 
    {
        _playerData = playerData;
        _playerMovement = playerMovement;
        _playerController = playerController;
        _lightController = lightController;
        _uiController = uiController;
    }

    public void InvokeMove(Vector2 dir2, bool sprintHeld) 
    {
        _playerMovement.Move(dir2, _playerData.Rb, _playerData.Sr, _playerData.Anim,
                            _playerData.WalkSpeed, _playerData.SprintSpeed,
                            _playerData.SprintDuration, _playerData.SprintRecharge, sprintHeld, _playerData.CanMove);
    }

    public void InvokeCollect() 
    {
        _playerController.Collect();
    }

    public void InvokeUvEnable() 
    {
        _lightController.EnableUV();
    }

    public void InvokeUvDisable()
    {
        _lightController.DisableUV();
    }

    public void InvokePause() 
    {
        _uiController.Pause();
    }

    public void InvokeJournal() 
    {
        _uiController.Journal();
    }
}
