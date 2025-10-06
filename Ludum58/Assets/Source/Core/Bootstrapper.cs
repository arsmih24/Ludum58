using PlayerSystem;
using LightSystem;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private LightController lightController;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        Invoker invoker = new(playerData, playerMovement, playerInventory, lightController);

        inputListener.Construct(invoker);
    }
}
