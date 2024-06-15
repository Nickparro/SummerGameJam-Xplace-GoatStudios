using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
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
