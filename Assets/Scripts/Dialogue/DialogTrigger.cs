using UnityEngine;

public class DialogTrigger : MonoBehaviour, IInteractable
{
    [Header("Entity")]
    [SerializeField] private Entity _entity;

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
