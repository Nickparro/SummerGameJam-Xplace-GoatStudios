using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Interact interact;

    [SerializeField] private Transform key;
    [SerializeField] private Transform mouseTransform;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 10);  // Offset de la llave respecto al jugador
    private bool isFollowing = false;  // Estado de seguimiento de la llave
    void Start()
    {

        interact = GetComponent<Interact>();

        key = GetComponent<Transform>();
        mouseTransform = GameObject.Find("MousePlayer").GetComponent<Transform>();
       

        if (interact != null)
        {
            interact.GetInteractEvent.HasInteracted += CatchKey;
            interact.GetInteractEvent.CanView += ShowOpenIcon;
            interact.GetInteractEvent.HideView += HideOpenIcon;
        }
    }

    void OnDestroy()
    {
        if (interact != null)
        {
            interact.GetInteractEvent.HasInteracted -= CatchKey;
            interact.GetInteractEvent.CanView -= ShowOpenIcon;
            interact.GetInteractEvent.HideView -= HideOpenIcon;
        }
    }

    void Update()
    {
        if (isFollowing)
        {
            // Actualiza la posición de la llave para seguir al jugador con un offset
            key.position = mouseTransform.position + offset;
        }
    }

    private void CatchKey()
    {
    
        if (key != null )
        {
            isFollowing = !isFollowing;  // Alterna el estado de seguimiento
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