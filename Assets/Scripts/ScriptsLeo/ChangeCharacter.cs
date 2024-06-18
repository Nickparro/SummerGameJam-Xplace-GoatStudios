using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mousePlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private float switchRange = 5.0f;
    [SerializeField] private bool isPlayerActive;

    private PlayerController playerController;
    private CinemachineVirtualCamera virtualCamera;
    private Animator playerAnimator;
    private Rigidbody playerRigidbody;
    private Rigidbody mousePlayerRigidbody;

    void Start()
    {
        InitializeReferences();
        SetInitialCharacterState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TrySwitchCharacter();
        }
    }

    private void InitializeReferences()
    {
        player = GameObject.Find("Player");
        mousePlayer = GameObject.Find("MousePlayer");

        mousePlayer.transform.SetParent(player.transform);

        playerController = player.GetComponent<PlayerController>();
        playerAnimator = player.GetComponentInChildren<Animator>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        mousePlayerRigidbody = mousePlayer.GetComponent<Rigidbody>();

        virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = player.transform;
    }

    private void SetInitialCharacterState()
    {
        mousePlayer.SetActive(false);
        isPlayerActive = true;
    }

    private void TrySwitchCharacter()
    {
        float distance = Vector3.Distance(player.transform.position, mousePlayer.transform.position);

        if (distance <= switchRange)
        {
            SwitchCharacter();
        }
    }

    private void SwitchCharacter()
    {
        if (isPlayerActive)
        {
            ActivateMousePlayer();
        }
        else
        {
            ActivatePlayer();
        }
    }

    private void ActivateMousePlayer()
    {
        isPlayerActive = false;
        playerAnimator.SetFloat("Velocity", 0);
        playerController.enabled = false;

        PositionMousePlayerNearPlayer();
        ResetMousePlayerPhysics();

        mousePlayer.SetActive(true);
        virtualCamera.Follow = mousePlayer.transform;
        virtualCamera.m_Lens.FieldOfView = 8;
    }

    private void PositionMousePlayerNearPlayer()
    {
        mousePlayer.transform.position = player.transform.position + new Vector3(1, 0, -0.5f);
    }

    private void ResetMousePlayerPhysics()
    {
        mousePlayerRigidbody.velocity = Vector3.zero;
        mousePlayerRigidbody.angularVelocity = Vector3.zero;
    }

    private void ActivatePlayer()
    {
        isPlayerActive = true;
        playerController.enabled = true;

        mousePlayer.SetActive(false);
        virtualCamera.Follow = player.transform;
        virtualCamera.m_Lens.FieldOfView = 20;
    }
}
