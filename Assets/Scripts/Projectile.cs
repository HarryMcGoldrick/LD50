
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public int collisionsBeforeDestroy = 1;
    public float lifeTime = 20f;
    private int collisions = 0;
    private Rigidbody2D rb;
    private Vector3 target;
    private GunStats stats;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        LaunchProjectile(target);
        Destroy(this.gameObject, lifeTime);
    }

    public void IntiailizeProjectile(Vector3 target, GunStats stats)
    {
        this.target = target;
        this.stats = stats;
    }

    private void LaunchProjectile(Vector3 target)
    {
        Vector2 direction = target - this.transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.rb.velocity = direction * stats.projectileSpeed;
    }

    private void HandleCollision(Collider2D collision)
    {
        collisions++;
        if (collisions >= collisionsBeforeDestroy)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerUtils.Instance.IsPlayerObject(collision.gameObject) || collision.gameObject.CompareTag("Pickup") || collision.gameObject.CompareTag("Projectile"))
            return;

        if (collision.TryGetComponent<Damagable>(out Damagable damagable))
        {
            damagable.InflictDamage(stats.damage, this.transform.position);
        }

        if (collision.TryGetComponent<RigidbodyKnockback>(out RigidbodyKnockback knockback))
        {
            Vector2 direction = (collision.transform.position - this.transform.position).normalized;
            knockback.Knockback(direction, stats.knockbackForce);
        }
        
        HandleCollision(collision);
    }
}