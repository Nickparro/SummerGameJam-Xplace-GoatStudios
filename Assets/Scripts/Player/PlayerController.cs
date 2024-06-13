using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private PlayerInput _playerInput;

    [Header("Animations")]
    [SerializeField] private PlayerVisual _playerVisual;

    [Header("Values")]
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float _crouchSpeedFactor;
    [SerializeField] private Collider _crouchDisableCollider;

    private Rigidbody _playerRb;
    
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _crouchDisableCollider.enabled = !_playerInput.IsCrouching;

        _playerVisual.SetVelocity(Mathf.Abs(_playerRb.velocity.x), _maxSpeed);
        _playerVisual.SetCrouching(_playerInput.IsCrouching);
    }

    private void FixedUpdate()
    {
        float increment = _playerInput.XInput * _acceleration;

        float newSpeed = _playerRb.velocity.x + increment;
        newSpeed = Mathf.Clamp(newSpeed, -_maxSpeed, _maxSpeed);

        float crouchModifier = _playerInput.IsCrouching ? _crouchSpeedFactor : 1.0f;
        _playerRb.velocity = newSpeed * crouchModifier * Vector3.right;

        float direction = 90.0f * Mathf.Sign(_playerRb.velocity.x) - 90.0f;
        transform.rotation = Quaternion.Euler(0.0f, direction, 0.0f);
    }
}
