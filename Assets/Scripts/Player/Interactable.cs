using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject _visualCue;

    [Header("Collision")]
    [SerializeField] private LayerMask _playerMask = 64;

    private PlayerInput _playerInput;
    protected bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerInput = player.GetComponent<PlayerInput>();
        _playerInput.OnInteraction += Interact;

        _visualCue.SetActive(false);
    }

    private void Update()
    {
        _visualCue.SetActive(_playerInRange && DialogManager.Instance.DialogIsPlaying == false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
            _playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
            _playerInRange = false;
    }
    protected abstract void Interact();
}


