using UnityEngine;
using PlayerSystem;

public class Invoker
{
    private PlayerData _playerData;
    private PlayerMovement _playerMovement;

    public Invoker(PlayerData playerData, PlayerMovement playerMovement) 
    {
        _playerData = playerData;
        _playerMovement = playerMovement;
    }

    public void InvokeMove(Vector2 dir2, bool sprintHeld) 
    {
        _playerMovement.Move(dir2, _playerData.Rb, _playerData.Sr, _playerData.Anim,
                            _playerData.WalkSpeed, _playerData.SprintSpeed,
                            _playerData.SprintDuration, _playerData.SprintRecharge, sprintHeld);
    }
}
