using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWrapper : MonoBehaviour
{
    [SerializeField] private State _requiredState;
    public void EnterDialog(TextAsset dialog)
    {
        if(_requiredState == null || (StateManager.Instance != null && StateManager.Instance.CurrentState == _requiredState))
            DialogManager.Instance.EnterDialogMode(dialog);
    }
}
