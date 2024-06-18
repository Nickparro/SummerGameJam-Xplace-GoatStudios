using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool lookingRight = true;

    [Header("Salto")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private Vector3 groundCheckOffset = new Vector3(0, -1, 0);

    private Rigidbody ratRigidbody;
    private Animator ratAnimator;
    private Transform cameraTransform;
    private bool isGrounded;

    private void Awake()
    {
        ratRigidbody = GetComponent<Rigidbody>();
        ratAnimator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        isGrounded = CheckGrounded();
        Move();
        Jump();
        UpdateAnimator();
    }

    private void Move()
    {
        if (!isGrounded) return;

        Vector3 moveDirection = GetMoveDirection();
        ratRigidbody.velocity = new Vector2(moveSpeed * moveDirection.x, ratRigidbody.velocity.y);

        if (ShouldTurn(moveDirection.x))
        {
            Turn();
        }
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        return Input.GetAxis("Horizontal") * right;
    }

    private bool ShouldTurn(float moveDirectionX)
    {
        return (moveDirectionX < 0 && lookingRight) || (moveDirectionX > 0 && !lookingRight);
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        transform.Rotate(0, 180, 0);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ratRigidbody.velocity = new Vector2(ratRigidbody.velocity.x, jumpForce);
        }
    }

    private bool CheckGrounded()
    {
        return Physics.CheckSphere(transform.position + groundCheckOffset, groundCheckRadius, groundLayer);
    }

    private void UpdateAnimator()
    {
        ratAnimator.SetFloat("HorizontalSpeed", Mathf.Abs(ratRigidbody.velocity.x));
        ratAnimator.SetBool("IsGrounded", isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + groundCheckOffset, groundCheckRadius);
    }
}
