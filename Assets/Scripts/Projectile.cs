
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 target;
    private float speed;
    private float damage;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        LaunchProjectile(target);
    }

    public void IntiailizeProjectile(Vector3 target, float speed, float damage)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
    }
    private void LaunchProjectile(Vector3 target)
    {
        Vector2 direction = target - PlayerUtils.Instance.GetPlayerPosition();
        direction.Normalize();
        this.rb.velocity = direction * speed;
    }

    private void HandleCollision(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerUtils.Instance.IsPlayerObject(collision.gameObject))
            HandleCollision(collision);

        //if (collision.TryGetComponent<Damagable>(out Damagable damagable))
        //{
            //damagable.InflictDamage(damage, this.transform.position);
        //}
    }
}