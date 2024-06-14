using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractRat : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private int maxColliders = 3;
    [SerializeField] private float interactionRadius = 7f;

    private Collider[] colliders;
    private Interact currentInteractable;
    private Interact lastInteractable;
    private int numCollidersFound;

    void Start()
    {
        interactionPoint = GetComponent<Transform>();
        colliders = new Collider[maxColliders];
    }

    void Update()
    {
        CheckForInteractableObjects();
        if (currentInteractable != null && numCollidersFound > 0 && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    private void OnDrawGizmos()
    {
        if (interactionPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }

    private void InteractWithObject()
    {
        Debug.Log("Trying to interact...");
        currentInteractable?.CallInteract(this);
    }

    private void CheckForInteractableObjects()
    {
        numCollidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactableLayerMask);
        if (numCollidersFound > 0)
        {
            int closestIndex = GetClosestColliderIndex();
            currentInteractable = colliders[closestIndex].GetComponent<Interact>();
            currentInteractable?.CallView();
            if (currentInteractable != lastInteractable)
            {
                lastInteractable?.CallHideView();
            }
            lastInteractable = currentInteractable;
        }
        else
        {
            lastInteractable?.CallHideView();
            currentInteractable = null;
        }
    }

    private int GetClosestColliderIndex()
    {
        float closestDistance = float.PositiveInfinity;
        int closestIndex = 0;

        for (int i = 0; i < numCollidersFound; i++)
        {
            float distance = Vector3.Distance(interactionPoint.position, colliders[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

}

