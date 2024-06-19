using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteractable 
{
    [SerializeField] private Animator doorAnimator;
    private bool isOpen;

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
    }
}

