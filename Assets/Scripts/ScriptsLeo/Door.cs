using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour , IInteractable 
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private GameObject visualCue;
    private bool isOpen;
    public GameObject VisualCue => visualCue;

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("IsOpen", isOpen);
    }

    
}

