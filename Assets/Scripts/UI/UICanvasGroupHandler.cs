using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasGroupHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public void SetCanvasGroup(bool show)
    {
        _canvasGroup.alpha = show ? 1.0f : 0.0f;
        _canvasGroup.interactable = show;
        _canvasGroup.blocksRaycasts = show;
    }
}
