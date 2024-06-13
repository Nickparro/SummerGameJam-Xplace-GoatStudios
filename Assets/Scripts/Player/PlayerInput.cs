using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    private InputAction _moveAction;
    private InputAction _crouchAction;

    private float _xInput;
    private bool _isCrouching;

    public float XInput => _xInput;
    public bool IsCrouching => _isCrouching;

    private void Start()
    {
        _playerInputs = new();
        _moveAction = _playerInputs.Gameplay.Move;
        _crouchAction = _playerInputs.Gameplay.Crouch;

        _crouchAction.performed += (x => SetCrouch(true));
        _crouchAction.canceled += (x => SetCrouch(false));

        _playerInputs.Enable();
    }

    private void OnEnable() => _playerInputs?.Enable();
    private void OnDisable() => _playerInputs?.Disable();

    private void Update() => _xInput = _moveAction.ReadValue<float>();

    private void SetCrouch(bool state) => _isCrouching = state;

}