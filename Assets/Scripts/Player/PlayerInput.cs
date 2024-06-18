using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    private InputAction _moveAction;
    private InputAction _crouchAction;
    private InputAction _interactAction;

    private float _xInput;
    private bool _isCrouching;
    private bool _isInverted;

    public float XInput => _xInput;
    public bool IsCrouching => _isCrouching;

    public event Action OnInteraction;

    private void Start()
    {
        _playerInputs = new();
        _moveAction = _playerInputs.Gameplay.Move;
        _crouchAction = _playerInputs.Gameplay.Crouch;
        _interactAction = _playerInputs.Gameplay.Interact;

        _crouchAction.performed += (x => SetCrouch(true));
        _crouchAction.canceled += (x => SetCrouch(false));

        _interactAction.canceled += x => OnInteraction?.Invoke();
        
        _playerInputs.Enable();
    }

    private void OnEnable() => _playerInputs?.Enable();
    private void OnDisable() => _playerInputs?.Disable();

    private void Update()
    {
        if(_isInverted == false)
            _xInput = _moveAction.ReadValue<float>();
        else
            _xInput = -_moveAction.ReadValue<float>();
    }

    private void SetCrouch(bool state) => _isCrouching = state;

    public void InvertMovement() => _isInverted = !_isInverted;

}