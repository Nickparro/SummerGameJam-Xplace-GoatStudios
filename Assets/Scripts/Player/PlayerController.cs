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
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float _speedDecay;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float _crouchSpeedFactor;
    [SerializeField] private SphereCollider _crouchDisableCollider;
    [SerializeField] private LayerMask _whatIsGround;

    private Rigidbody _playerRb;
    private bool _ceilingCheck;
    
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_ceilingCheck == true)
            _crouchDisableCollider.isTrigger = true;
        else
            _crouchDisableCollider.isTrigger = _playerInput.IsCrouching;


        _playerVisual.SetVelocity(Mathf.Abs(_playerRb.velocity.x), _maxSpeed);
        _playerVisual.SetCrouching(_crouchDisableCollider.isTrigger);
    }

    private void FixedUpdate()
    {
        _ceilingCheck = Physics.CheckSphere(transform.position + _crouchDisableCollider.center, 
                                            _crouchDisableCollider.radius, _whatIsGround);
        if(_playerInput.enabled == true && DialogManager.Instance.DialogIsPlaying == false)
        {
            if(_playerInput.XInput != 0.0f)
            {
                float increment = _playerInput.XInput * _acceleration;

                float newSpeed = _playerRb.velocity.x + increment;
                newSpeed = Mathf.Clamp(newSpeed, -_maxSpeed, _maxSpeed);

                float crouchModifier = _crouchDisableCollider.isTrigger ? _crouchSpeedFactor : 1.0f;
                _playerRb.velocity = new(newSpeed * crouchModifier, _playerRb.velocity.y);
                SetLookDirection();
            }
            else
            {
                _playerRb.velocity = new(_playerRb.velocity.x * _speedDecay, _playerRb.velocity.y);
            }
            
        }
        else
            _playerRb.velocity = Vector3.zero;
    }

    private void SetLookDirection()
    {
        if (_playerRb.velocity.x > 0.1f)
            _playerVisual.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        else if (_playerRb.velocity.x < -0.1f)
            _playerVisual.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
    }

    public void Interact(ActionType action, AnimationCurve xDisplacement, AnimationCurve yDisplacement, bool facesRight)
    {
        _playerInput.enabled = false;
        _playerVisual.Play(action.Clip.name);
        if (action.DisplacesPlayer == true)
        {
            transform.rotation = Quaternion.Euler(0.0f, facesRight ? 0.0f : 180.0f, 0.0f);
            StartCoroutine(DisplacePlayer(xDisplacement, yDisplacement, action.Clip.length));
        }
        else
            _playerInput.enabled = true;
    }

    private IEnumerator DisplacePlayer(AnimationCurve xDisplacement, AnimationCurve yDisplacement, float duration)
    {
        Vector3 initialPos = transform.position;
        Vector3 finalPos = initialPos + new Vector3(xDisplacement.Evaluate(1.0f), yDisplacement.Evaluate(1.0f));
        float elapsedTime = 0.0f;
        while (Vector3.Distance(transform.position, finalPos) >= 0.1f)
        {
            elapsedTime += Time.deltaTime;
            float ratio = elapsedTime / duration;
            transform.position = initialPos + new Vector3(xDisplacement.Evaluate(ratio), yDisplacement.Evaluate(ratio));
            yield return null;
        }
        _playerInput.enabled = true;
    }

}
