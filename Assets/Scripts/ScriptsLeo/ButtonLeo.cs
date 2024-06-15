using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeo : MonoBehaviour
{
    private Interact interact;
   
    [SerializeField] private GameObject buttonOn;
    [SerializeField] private GameObject buttonOff;

    void Start()
    {
        buttonOff = GameObject.Find("ButtonOff");
        buttonOn = GameObject.Find("ButtonOn");

        buttonOn.gameObject.SetActive(false);

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
             
        if (buttonOn != null && buttonOff != null)
        {
            bool isActive = buttonOn.activeSelf;
            buttonOn.SetActive(!isActive);
            buttonOff.SetActive(isActive);
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
