using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorElevator : MonoBehaviour , IInteractable 
{
    [SerializeField] private Animator doorElevatorAnimator;
    [SerializeField] private GameObject visualCue;
    private bool isOpen;
    public GameObject VisualCue => visualCue;

    public void Interact()
    {
        isOpen = !isOpen;
        Debug.Log("Door is open?: " + isOpen);
        doorElevatorAnimator.SetBool("IsOpen", isOpen);  
    }  

    public void OpenDoor()
    {
        Debug.Log("Isopen: " + isOpen);        
        if (isOpen == true) return;
        Debug.Log("OpenDoor");
        isOpen = true;
        doorElevatorAnimator.SetBool("IsOpen", isOpen);
    }

    public void CloseDoor()
    {
        Debug.Log("Isopen: " + isOpen);
        //if (isOpen == false) return;
        Debug.Log("CloseDoor");
        isOpen = false;      
        doorElevatorAnimator.SetBool("IsOpen", isOpen);
    }
}

