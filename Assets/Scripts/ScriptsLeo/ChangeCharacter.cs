using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] private GameObject mousePlayer, player;
    [SerializeField] private PlayerController pcPlayer;
    [SerializeField] private bool isPlayer;

    private CinemachineVirtualCamera cinemachineVirtualCamera;

    void Start()
    {
        player = GameObject.Find("Player");
        mousePlayer = GameObject.Find("MousePlayer");
        mousePlayer.transform.SetParent(player.transform);
        pcPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
        mousePlayer.SetActive(false);
        isPlayer = true;

        cinemachineVirtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (isPlayer)
            {
                isPlayer = false;
                pcPlayer.enabled = false;
                mousePlayer.SetActive(true);
                cinemachineVirtualCamera.Follow = mousePlayer.transform;
                cinemachineVirtualCamera.m_Lens.FieldOfView = 8;
            }
            else
            {
                isPlayer = true;
                pcPlayer.enabled = true;
                mousePlayer.SetActive(false);
                cinemachineVirtualCamera.Follow = player.transform;
                cinemachineVirtualCamera.m_Lens.FieldOfView = 20;
            }
        }
        
    }
}
