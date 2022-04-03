using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDestroy : MonoBehaviour
{
    public GameObject explosionProjectile;
    public GunStats projectileStats;
    public int projectileCount;

    private void OnDestroy()
    {
        Explode();
    }

    private void Explode()
    {
        float radius = 1 + (projectileCount * 0.2f);
        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projGO = Instantiate(explosionProjectile);
            Projectile projComp = projGO.GetComponent<Projectile>();
            projComp.transform.position = this.transform.position;
            projComp.IntiailizeProjectile(GetCirclePosition(this.transform.position, radius, i), projectileStats);
        }
    }

    private Vector2 GetCirclePosition(Vector2 CenterPosition, float radius, int count)
    {
        float x = radius * Mathf.Cos(count) + CenterPosition.x;
        float y = radius * Mathf.Sin(count) + CenterPosition.y;
        return new Vector2(x, y);
    }
}
