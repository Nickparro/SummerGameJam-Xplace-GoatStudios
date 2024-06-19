using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask = 64;
    [SerializeField] private TMP_Text _text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
        {
            _text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Mathf.Log(_playerMask, 2))
        {
            _text.enabled = false;
        }
    }
}
