using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlipSpriteOnVelocityDirection : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleFlip();
    }

    private void HandleFlip()
    {
        Vector3 velocity = this.rb.velocity;
        if (velocity.x >= 0)
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        else
            this.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
