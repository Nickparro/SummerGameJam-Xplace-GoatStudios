using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [SerializeField] private int totalFloors = 5;
    [SerializeField] private float distanceBetweenFloors = 3f;
    [SerializeField] private TextMeshProUGUI currentFloorText;
    [SerializeField] private GameObject elevatorUI;
    [SerializeField] private TMP_Dropdown floorDropdown;

    private int currentFloor = 0;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        elevatorUI.SetActive(false);
        UpdateCurrentFloorText();
        PopulateFloorDropdown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "MousePlayer")
        {
            elevatorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "MousePlayer")
        {
            elevatorUI.SetActive(false);
        }
    }

    public void OnFloorSelected(int floorIndex)
    {
        if (!isMoving && floorIndex != currentFloor)
        {
            currentFloor = floorIndex;
            targetPosition = new Vector3(transform.position.x, floorIndex * distanceBetweenFloors, transform.position.z);
            StartCoroutine(MoveElevator());
        }
    }

    private IEnumerator MoveElevator()
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2f);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
        UpdateCurrentFloorText();
    }

    private void UpdateCurrentFloorText()
    {
        currentFloorText.text = "Current Floor: " + (currentFloor + 1);
    }

    private void PopulateFloorDropdown()
    {
        floorDropdown.options.Clear();
        for (int i = 0; i < totalFloors; i++)
        {
            floorDropdown.options.Add(new TMP_Dropdown.OptionData("Floor " + (i+1) ));
        }
        floorDropdown.onValueChanged.AddListener(OnFloorSelected);
    }
}
