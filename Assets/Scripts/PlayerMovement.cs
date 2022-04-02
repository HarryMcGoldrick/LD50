using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidBody;
    //private Animator animator;
    private Vector2 moveDirection;

    private void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        //this.animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SetMovementDirection();
        //SetAnimatorParameters();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetMovementDirection()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(InputX, InputY).normalized;
    }

    //private void SetAnimatorParameters()
    //{
    //    this.animator.SetFloat("Velocity", this.rigidBody.velocity.magnitude);
    //}

    private void Move()
    {
        this.rigidBody.velocity = moveDirection * moveSpeed;
    }
}
