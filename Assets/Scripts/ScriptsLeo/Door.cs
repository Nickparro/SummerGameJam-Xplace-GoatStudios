using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteractable 
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private StringEvent _playAudioEvent;
    private bool isOpen;

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
        _playAudioEvent.Invoke("SFX_Door");
    }

    public void SetDoorState(bool state)
    {
        if (isOpen == state) return;
        isOpen = state;
        doorAnimator.SetBool("IsOpen", isOpen);
        _playAudioEvent.Invoke("SFX_Door");
    }
}

