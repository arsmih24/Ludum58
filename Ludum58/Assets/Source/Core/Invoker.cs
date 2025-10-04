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
}
