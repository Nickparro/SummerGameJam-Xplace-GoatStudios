using Cinemachine;
using UnityEngine;

public class ShipSideTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _visualCue;
    [SerializeField] private Fade fade;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private PlayerInput playerInput;
    private CinemachineFramingTransposer cameraTransposer;
    private bool isWest = false;
    public GameObject VisualCue => _visualCue;

    private void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        playerInput.InvertMovement();
    }
    public void Interact()
    {
        fade.FadeOut();
        Invoke(nameof(ChangePosition), .9f);
    }

    public void ChangePosition()
    {
        playerInput.InvertMovement();
        if (isWest)
        {
            playerInput.transform.position = new Vector3(20.0f, 9.0f, 3.0f);
            virtualCamera.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            isWest = false;
        }
        else
        {
            playerInput.transform.position = new Vector3(20.0f, 9.0f, -3.0f);
            virtualCamera.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            isWest = true;
        }
    }
}
