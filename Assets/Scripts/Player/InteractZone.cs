using System.Collections;
using UnityEngine;

public class InteractZone : MonoBehaviour, IInteractable
{
    [Header("Interaction")]
    [SerializeField] private GameObject _visualCue;
    [SerializeField] private ActionType _actionType;
    [SerializeField] private AnimationCurve _xDisplacement;
    [SerializeField] private AnimationCurve _yDisplacement;
    [SerializeField] private bool _facesRight;

    private PlayerController _playerController;

    public GameObject VisualCue => _visualCue;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
    }

    public void Interact()
    {
        _playerController.transform.position = new Vector3(transform.position.x,
                                                    _playerController.transform.position.y,
                                                    _playerController.transform.position.z);

        _playerController.Interact(_actionType, _xDisplacement, _yDisplacement, _facesRight);
    }
}
