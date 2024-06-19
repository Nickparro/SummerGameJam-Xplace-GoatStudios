using UnityEngine;

public class StateTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask = 64;
    [SerializeField] private State _requiredState;
    [SerializeField] private State _newState;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Mathf.Log(_playerMask, 2))
        {
            if(StateManager.Instance.CurrentState == _requiredState)
                StateManager.Instance.ChangeState(_newState.name);
        }
    }
}
