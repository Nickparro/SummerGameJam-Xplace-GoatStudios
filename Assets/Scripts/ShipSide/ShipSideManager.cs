using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSideManager : MonoBehaviour
{
    public PlayerController playerController;
    public Fade fade;
    public Transform virtualCamera;
    public bool inWest = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fade.FadeOut();
            Invoke("ChangeShipSide", .9f);
        }
    }
    public void ChangeShipSide()
    {
        if (inWest)
        {
            playerController.transform.position = new Vector3(20, 9, 3);
            virtualCamera.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            inWest = false;
        }
        else
        {
            playerController.transform.position = new Vector3(20, 9, -3);
            virtualCamera.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            inWest = true;
        }

    }
}
