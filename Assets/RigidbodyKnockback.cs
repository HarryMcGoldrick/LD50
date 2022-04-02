using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer;
    private float force;
    private Vector3 direction;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
            this.rb.AddForce(direction * force);
    }

    public void Knockback(Vector3 direction, float force, float duration = 0.15f)
    {
        Debug.Log("Knockback: " + force);
        this.force = force;
        this.direction = direction;
        this.timer = duration;
    }
}
