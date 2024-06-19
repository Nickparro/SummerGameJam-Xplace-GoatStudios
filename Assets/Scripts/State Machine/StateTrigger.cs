using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask = 64;
    [SerializeField] private string _newState;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Mathf.Log(_playerMask, 2))
        {
            StateManager.Instance.ChangeState(_newState);
        }
    }
}
