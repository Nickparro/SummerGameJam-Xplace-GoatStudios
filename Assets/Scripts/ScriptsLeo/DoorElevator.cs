using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElevator : MonoBehaviour , IInteractable 
{
    [SerializeField] private Animator doorElevatorAnimator;
    [SerializeField] private GameObject visualCue;
    public bool isOpen;
    public GameObject VisualCue => visualCue;

    public void Interact()
    {
        isOpen = !isOpen;
        doorElevatorAnimator.SetBool("IsOpen", isOpen);  
    }

    
    
}

