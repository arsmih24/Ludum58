using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private MainInputActions _mainInputActions;
    private Invoker _invoker;
    private Vector2 _inputValue;
    private bool _isSprinting = false;

    public void Construct(Invoker invoker) 
    {
        _invoker = invoker;
    }

    private void Awake()
    {
        _mainInputActions = new();
        Bind();
        _mainInputActions.Enable();
    }

    private void FixedUpdate()
    {
        _invoker.InvokeMove(_inputValue, _isSprinting);
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _inputValue = context.ReadValue<Vector2>();
    }

    private void OnSprintStarted(InputAction.CallbackContext context) 
    {
        _isSprinting = true;
    }

    private void OnSprintEnded(InputAction.CallbackContext context)
    {
        _isSprinting = false;
    }

    private void OnCollect(InputAction.CallbackContext context)
    {
        _invoker.InvokeCollect();
    }

    private void OnUltraviolet(InputAction.CallbackContext context)
    {
        _invoker.InvokeUvEnable();
    }

    private void OffUltraviolet(InputAction.CallbackContext context)
    {
        _invoker.InvokeUvDisable();
    }

    private void Bind() 
    {
        _mainInputActions.Game.Move.performed += OnMovement;
        _mainInputActions.Game.Sprint.performed += OnSprintStarted;
        _mainInputActions.Game.Sprint.canceled += OnSprintEnded;
        _mainInputActions.Game.Collect.performed += OnCollect;
        _mainInputActions.Game.UltraViolet.performed += OnUltraviolet;
        _mainInputActions.Game.UltraViolet.canceled += OffUltraviolet;
    }

    private void Expose() 
    {
        _mainInputActions.Game.Move.performed -= OnMovement;
        _mainInputActions.Game.Sprint.performed -= OnSprintStarted;
        _mainInputActions.Game.Sprint.canceled -= OnSprintEnded;
        _mainInputActions.Game.Collect.performed += OnCollect;
        _mainInputActions.Game.UltraViolet.performed -= OnUltraviolet;
        _mainInputActions.Game.UltraViolet.canceled -= OffUltraviolet;
    }

    private void OnDestroy()
    {
        _mainInputActions.Disable();
        Expose();
    }
}
