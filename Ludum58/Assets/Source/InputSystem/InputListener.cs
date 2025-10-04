using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private MainInputActions _mainInputActions;
    private Invoker _invoker;

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

    private void Bind() 
    {

    }

    private void Expose() 
    {

    }
}
