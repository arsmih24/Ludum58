using PlayerSystem;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        Invoker invoker = new(playerData, playerMovement);

        inputListener.Construct(invoker);
    }
}
