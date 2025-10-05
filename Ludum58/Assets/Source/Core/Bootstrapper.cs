using PlayerSystem;
using LightSystem;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private LightController lightController;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        Invoker invoker = new(playerData, playerMovement, lightController);

        inputListener.Construct(invoker);
    }
}
