using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] float moveSpeed;
    Rigidbody theRB;

    [SerializeField] bool lookingRight = true;

    [Header("Salto")]
    [SerializeField] float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = -0.11f;
    [SerializeField] float additionalGravity = 9.81f;

    [SerializeField] private Animator animator;

    public Vector3 groundCheckOffset = new Vector3(0, -1, 0);
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRat();
        Jump();
        isGrounded = Physics.CheckSphere(transform.position + groundCheckOffset, groundCheckRadius, groundLayer);
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(theRB.velocity.x));
        animator.SetBool("IsGrounded", isGrounded);

    
    }

    
    void MoveRat()
    {
        if (isGrounded)
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            if (theRB.velocity.x < 0 && lookingRight)
            {
                Turn();
            }
            else if (theRB.velocity.x > 0 && !lookingRight)
            {
                Turn();
            }
        }
    }
    private void Turn()
    {
        lookingRight = !lookingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
          
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

        }
        else
        {
            theRB.velocity += Vector3.up * Physics.gravity.y * additionalGravity * Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + groundCheckOffset, groundCheckRadius);
    }
}
