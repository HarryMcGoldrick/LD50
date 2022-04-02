using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowardsPlayer : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        playerTransform = PlayerUtils.Instance.GetPlayerGameObject().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(playerTransform);
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z);
        Vector2 direction = (playerTransform.transform.position - this.transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
