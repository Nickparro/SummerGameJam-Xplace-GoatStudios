using UnityEngine;

public class DialogTrigger : Interactable
{
    [SerializeField] private GameObject _visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset _inkJson;

    private void Start()
    {
        _visualCue.SetActive(false);
    }

    private void Update()
    {
        _visualCue.SetActive(_playerInRange && DialogManager.Instance.DialogIsPlaying == false);
    }

    protected override void Interact()
    {
        if(DialogManager.Instance.DialogIsPlaying == false)
            DialogManager.Instance.EnterDialogMode(_inkJson);
    }
}
