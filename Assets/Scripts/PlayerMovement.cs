using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    private void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetMovementDirection();
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

    private void Move()
    {
        this.rigidBody.velocity = moveDirection * moveSpeed;
    }
}
