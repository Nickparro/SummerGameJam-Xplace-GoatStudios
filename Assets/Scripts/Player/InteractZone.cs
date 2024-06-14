using System.Collections;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] private LayerMask _playerMask = 64;

    [Header("Interaction")]
    [SerializeField] private ActionType _actionType;
    [SerializeField] private AnimationCurve _xDisplacement;
    [SerializeField] private AnimationCurve _yDisplacement;
    [SerializeField] private bool _facesRight;

    private PlayerController _playerController;
    private PlayerInput _playerInput;
    private bool _canPerformAction;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerInput = player.GetComponent<PlayerInput>();
        _playerController = player.GetComponent<PlayerController>();

        _playerInput.OnInteraction += Interact;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Mathf.Log(_playerMask, 2))
            _canPerformAction = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
            _canPerformAction = false;
    }

    private void Interact()
    {
        if (_canPerformAction == true)
        {
            _playerController.transform.position = new Vector3(transform.position.x,
                                                        _playerController.transform.position.y,
                                                        _playerController.transform.position.z);

            _playerController.Interact(_actionType, _xDisplacement, _yDisplacement, _facesRight);
            _canPerformAction = false;
        }
    }
}
