using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] private GameObject elevatorUI;
    [SerializeField] private Button[] floorButtons;
    [SerializeField] private Transform[] posFloors;

    private int currentFloor = 1; 
    private bool isMoving = false;
    private float moveSpeed = 2f;

    
    [SerializeField] private DoorElevator doorElevator;
    void Start()
    {
        for (int i = 0; i < floorButtons.Length; i++)
        {
            int j = i;
            floorButtons[i].onClick.AddListener(() => OnFloorSelected(j));
        }
        elevatorUI.SetActive(false);

        currentFloor = DetermineCurrentFloor();
        UpdateCurrentFloorText();
    }

    private int DetermineCurrentFloor()
    {
        float elevatorPosY = transform.position.y;
        for (int i = 0; i < posFloors.Length; i++)
        {
            if (elevatorPosY == posFloors[i].position.y) return i + 1;
        }
        return currentFloor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorElevator.SetDoorState(false);
            elevatorUI.SetActive(true);
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorElevator.SetDoorState(false);
            elevatorUI.SetActive(false);
            other.transform.SetParent(null);
        }
    }

    public void OnFloorSelected(int floorNumber)
    {
        if (!isMoving && floorNumber != currentFloor)
        {
            Vector3 targetPos = posFloors[floorNumber].position;
            StartCoroutine(MoveElevator(targetPos, floorNumber));
        }
    }

    private IEnumerator MoveElevator(Vector3 targetPos, int targetFloor)
    {
        isMoving = true;
        doorElevator.SetDoorState(false);
        yield return new WaitForSeconds(1f);  
        
        int direction = (targetPos.y > transform.position.y) ? 1 : -1;

        while (Mathf.Abs(transform.position.y - targetPos.y) > 0.05f)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

        currentFloor = targetFloor;
        
        UpdateCurrentFloorText();

        doorElevator.SetDoorState(true);

    }

    private void UpdateCurrentFloorText()
    {
        currentFloorText.text = "Current Floor: " + DetermineCurrentFloor();
    }
}
