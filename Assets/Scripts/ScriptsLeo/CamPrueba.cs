using UnityEngine;

public class CamPrueba : MonoBehaviour
{
    [SerializeField] private Transform mouseTransform;  
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10);  
    [SerializeField] private float smoothSpeed = 0.125f;  
    void Start()
    {
        mouseTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (mouseTransform != null)
        {
            Vector3 desiredPosition = mouseTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

  //Cambiar el offset desde otros script para hacer cambio del player a la ratas
    public void SetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }
}
