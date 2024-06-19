using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogWrapper : MonoBehaviour
{
    public void EnterDialog(TextAsset dialog) => DialogManager.Instance.EnterDialogMode(dialog);
}
