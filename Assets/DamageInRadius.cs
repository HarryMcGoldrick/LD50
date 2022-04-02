using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInRadius : MonoBehaviour
{
    public LayerMask layers;

    public float rate;
    public float damage;
    public float radius;
    public float force;

    private float timer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            InflictDamageInRadius();
            timer = rate;
        }
    }

    public void InflictDamageInRadius()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(this.transform.position, radius, layers);
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].TryGetComponent<Damagable>(out Damagable damagable))
            {
                damagable.InflictDamage(damage, colls[i].transform.position);
            }

            if (colls[i].TryGetComponent<RigidbodyKnockback>(out RigidbodyKnockback knockback))
            {
                knockback.Knockback(transform.position, colls[i].transform.position, force);
            }
        }
    }
}
