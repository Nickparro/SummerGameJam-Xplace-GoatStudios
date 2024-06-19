using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask = 64;
    [SerializeField] private Collider _collider;
    [SerializeField] private PlayableDirector _director;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
        {
            _collider.enabled = false;
            _director.Play();
        }
    }
}
