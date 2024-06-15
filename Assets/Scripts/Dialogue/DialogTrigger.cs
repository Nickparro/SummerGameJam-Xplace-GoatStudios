using UnityEngine;

public class DialogTrigger : Interactable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJson;

    protected override void Interact()
    {
        if(DialogManager.Instance.DialogIsPlaying == false)
            DialogManager.Instance.EnterDialogMode(_inkJson);
    }
}
