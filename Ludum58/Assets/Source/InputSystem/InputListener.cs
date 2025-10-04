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

    private void Bind() 
    {
        _mainInputActions.Game.Move.performed += OnMovement;
        _mainInputActions.Game.Sprint.performed += OnSprintStarted;
        _mainInputActions.Game.Sprint.canceled += OnSprintEnded;
    }

    private void Expose() 
    {
        _mainInputActions.Game.Move.performed -= OnMovement;
        _mainInputActions.Game.Sprint.performed -= OnSprintStarted;
        _mainInputActions.Game.Sprint.canceled -= OnSprintEnded;
    }

    private void OnDestroy()
    {
        _mainInputActions.Disable();
        Expose();
    }
}
