using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWall : MonoBehaviour
{
    private Interact interact;
   
    [SerializeField] private GameObject switchOn;
    [SerializeField] private GameObject switchOff;

    void Start()
    {
        switchOff = GameObject.Find("SwitchOff");
        switchOn = GameObject.Find("SwitchOn");

        switchOn.gameObject.SetActive(false);

        interact = GetComponent<Interact>();

        if (interact != null)
        {
            interact.GetInteractEvent.HasInteracted += TurnOnOff;
            interact.GetInteractEvent.CanView += ShowOpenIcon;
            interact.GetInteractEvent.HideView += HideOpenIcon;
        }
    }

    void OnDestroy()
    {
        if (interact != null)
        {
            interact.GetInteractEvent.HasInteracted -= TurnOnOff;
            interact.GetInteractEvent.CanView -= ShowOpenIcon;
            interact.GetInteractEvent.HideView -= HideOpenIcon;
        }
    }

    private void TurnOnOff()
    {
           
        if (switchOn != null && switchOff != null)
        {
            bool isActive = switchOn.activeSelf;
            switchOn.SetActive(!isActive);
            switchOff.SetActive(isActive);
        }
    }

    private void ShowOpenIcon()
    {
        //Debug.Log("Show open icon!");
        // Código para mostrar un icono de abrir puerta
    }

    private void HideOpenIcon()
    {
        //Debug.Log("Hide open icon!");
        // Código para ocultar el icono de abrir puerta
    }
}
