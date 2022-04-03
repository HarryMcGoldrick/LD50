using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public abstract class BasePickup : MonoBehaviour
{
    [Header("Base Pickup")]
    private Transform playerTransform;
    private float moveSpeed = 3;
    private float accel = 2;

    protected void Update()
    {
        if (playerTransform != null)
        {
            if (Vector2.Distance(playerTransform.position, this.transform.position) <= 0.5f)
            {
                ConsumePickup();
            }
            else
            {
                PullTowardsPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = PlayerUtils.Instance.GetPlayerGameObject().transform;
            PullTowardsPlayer();
        }
    }

    protected abstract void ConsumePickup();

    private void PullTowardsPlayer()
    {
        Vector3 moveDirection = (playerTransform.position - this.transform.position).normalized;
        moveSpeed += (accel * Time.deltaTime);
        this.transform.Translate(moveDirection * (moveSpeed + accel) * Time.deltaTime);
    }
}
