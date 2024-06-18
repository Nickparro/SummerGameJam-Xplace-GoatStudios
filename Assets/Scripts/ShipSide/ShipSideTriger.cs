using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSideTriger : MonoBehaviour
{
    public GameObject shipFliper;
    private void OnTriggerStay(Collider other)
    {
        shipFliper.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        shipFliper.SetActive(false);
    }
}
