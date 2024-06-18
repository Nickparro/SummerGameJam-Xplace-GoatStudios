using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] private GameObject elevatorUI;
    [SerializeField] private Button floor1, floor2, floor3, floor4;
    [SerializeField] private Transform posFloor1, posFloor2, posFloor3, posFloor4;

    private int currentFloor = 1; 
    private bool isMoving = false;
    private float moveSpeed = 2f;

    
    [SerializeField] private Animator doorElevatorAnimator;
    
    DoorElevator doorElevator;
    void Start()
    {
        
        doorElevator = GameObject.FindGameObjectWithTag("DoorElevator").GetComponent<DoorElevator>();

        floor1.onClick.AddListener(() => OnFloorSelected(1));
        floor2.onClick.AddListener(() => OnFloorSelected(2));
        floor3.onClick.AddListener(() => OnFloorSelected(3));
        floor4.onClick.AddListener(() => OnFloorSelected(4));
        
        elevatorUI.SetActive(false);

        currentFloor = DetermineCurrentFloor();
        UpdateCurrentFloorText();
    }

    private int DetermineCurrentFloor()
    {
        float elevatorPosY = transform.position.y;

        if (elevatorPosY == posFloor1.position.y)
        {
            
            return 1;
        }
        else if (elevatorPosY == posFloor2.position.y)
        {
            
            return 2;
        }
        else if (elevatorPosY == posFloor3.position.y)
        {
            
            return 3;
        }
        else if (elevatorPosY == posFloor4.position.y)
        {
            
            return 4;
        }

       
        return currentFloor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorElevator.Interact();
            elevatorUI.SetActive(true);
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorElevator.Interact();
            elevatorUI.SetActive(false);
            other.transform.SetParent(null);
        }
    }

    public void OnFloorSelected(int floorNumber)
    {
        if (!isMoving && floorNumber != currentFloor)
        {
            
            Vector3 targetPos = Vector3.zero;
            switch (floorNumber)
            {
                case 1:
                    targetPos = posFloor1.position;
                    break;
                case 2:
                    targetPos = posFloor2.position;
                    break;
                case 3:
                    targetPos = posFloor3.position;
                    break;
                case 4:
                    targetPos = posFloor4.position;
                    break;
            }

            
            StartCoroutine(MoveElevator(targetPos, floorNumber));
        }
    }


    private IEnumerator MoveElevator(Vector3 targetPos, int targetFloor)
    {
        
        if (doorElevator.isOpen == true) {
            doorElevator.isOpen = false;
            doorElevatorAnimator.SetBool("IsOpen", doorElevator.isOpen);
        }
       
        yield return new WaitForSeconds(1f);
        
        isMoving = true;

        
        targetPos = new Vector3(transform.position.x, targetPos.y, transform.position.z);

        
        int direction = (targetPos.y > transform.position.y) ? 1 : -1;
      
        
        while (Mathf.Abs(transform.position.y - targetPos.y) > 0.01f)
        {
            transform.Translate(Vector3.up * direction * Time.deltaTime * moveSpeed);
            yield return null;
        }

        
        transform.position = targetPos;
        isMoving = false;

        
        currentFloor = targetFloor;
        
        UpdateCurrentFloorText();

        doorElevator.Interact();
       

    }

    private void UpdateCurrentFloorText()
    {
        currentFloorText.text = "Current Floor: " + DetermineCurrentFloor();
    }
}
