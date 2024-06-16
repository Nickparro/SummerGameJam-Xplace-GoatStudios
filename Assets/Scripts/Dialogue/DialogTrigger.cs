using UnityEngine;

public class DialogTrigger : MonoBehaviour, IInteractable
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject _visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJson;

    public GameObject VisualCue => _visualCue;

    public void Interact()
    {
        if(DialogManager.Instance.DialogIsPlaying == false)
            DialogManager.Instance.EnterDialogMode(_inkJson);
    }
}
