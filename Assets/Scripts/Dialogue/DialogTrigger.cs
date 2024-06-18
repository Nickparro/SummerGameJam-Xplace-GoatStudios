using UnityEngine;

public class DialogTrigger : MonoBehaviour, IInteractable
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject _visualCue;

    [Header("Entity")]
    [SerializeField] private Entity _entity;

    public GameObject VisualCue => _visualCue;

    public void Interact()
    {
        if(DialogManager.Instance.DialogIsPlaying == false)
        {
            TextAsset inkJson = null;
            if (StateManager.Instance != null)
                inkJson = StateManager.Instance.CurrentState.GetDialog(_entity);
            DialogManager.Instance.EnterDialogMode(inkJson);
        }
    }
}
