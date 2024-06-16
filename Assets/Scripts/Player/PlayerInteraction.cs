using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _interactCenter;
    [SerializeField] private Vector3 _interactSize;
    [SerializeField] private LayerMask _interactableLayer;

    private IInteractable _currentInteractable;

    private void Awake()
    {
        _playerInput.OnInteraction += Interact;
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(_interactCenter.position, _interactSize,Quaternion.identity,_interactableLayer);
        if(colliders.Length > 0)
        {
            GameObject currentObject = colliders[0].gameObject;
            if (_currentInteractable == null)
            {
                currentObject.TryGetComponent(out _currentInteractable);
                _currentInteractable?.VisualCueVisibility(true);
            }
        }
        else
        {
            _currentInteractable?.VisualCueVisibility(false);
            _currentInteractable = null;
        }
            
        
    }

    private void Interact()
    {
        _currentInteractable?.Interact();
        _currentInteractable?.VisualCueVisibility(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_interactCenter.position, _interactSize * 2.0f);
    }
}
