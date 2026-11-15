using UnityEngine;
using UnityEngine.InputSystem;

public class QuitGame : MonoBehaviour, InputSystem_Actions.IQuitActions
{
    private InputSystem_Actions _inputActions;

    void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Quit.SetCallbacks(this);
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    public void OnQuitGame(InputAction.CallbackContext context)
    {
        Application.Quit();
    }
}
