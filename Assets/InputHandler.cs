using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class InputHandler : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    private InputScheme _inputs;
    private void Awake()
    {
        if (_birdMover == null){        
            enabled = false;
            return;
        }
        _inputs = new InputScheme();
    }
    private void OnEnable()
    {
        _inputs.Enable();
        _inputs.ActionMap.Touch.performed += OnTouch;
    }
    private void OnDisable()
    {
        _inputs.Disable();
        _inputs.ActionMap.Touch.performed -= OnTouch;
    }
    private void OnTouch(CallbackContext context)
    {
        _birdMover.Jump();
    }
}