using System.Collections;
using UnityEngine;

public class InteractZone : Interactable
{
    [Header("Interaction")]
    [SerializeField] private ActionType _actionType;
    [SerializeField] private AnimationCurve _xDisplacement;
    [SerializeField] private AnimationCurve _yDisplacement;
    [SerializeField] private bool _facesRight;

    private PlayerController _playerController;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
    }


    protected override void Interact()
    {
        if (_playerInRange == true)
        {
            _playerController.transform.position = new Vector3(transform.position.x,
                                                        _playerController.transform.position.y,
                                                        _playerController.transform.position.z);

            _playerController.Interact(_actionType, _xDisplacement, _yDisplacement, _facesRight);
            _playerInRange = false;
        }
    }
}
