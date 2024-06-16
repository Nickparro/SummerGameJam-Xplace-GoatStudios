using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] Animator doorAnimator;
    private bool isOpen;

    protected override void Interact()
    {
        if (_playerInRange == true)
        {
            isOpen = !isOpen;
            doorAnimator.SetBool("IsOpen", isOpen);
        }
    }

}
