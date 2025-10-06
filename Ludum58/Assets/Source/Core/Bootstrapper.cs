using UnityEngine;
using PlayerSystem;
using LightSystem;
using UiSystem;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LightController lightController;
    [SerializeField] private UiController uiController;

    private void Awake()
    {
        PlayerMovement playerMovement = new();
        Invoker invoker = new(playerData, playerMovement, playerController, lightController, uiController);

        inputListener.Construct(invoker);
        uiController.Construct(playerController, lightController);
    }
}
