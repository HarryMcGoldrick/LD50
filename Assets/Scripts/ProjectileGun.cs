using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileGun", menuName = "Guns/ProjectileGun")]
public class ProjectileGun : BaseGun
{
    public GameObject projectilePrefab;

    protected override void Fire()
    {
        if (muzzleTransform != null)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectileGO.transform.position = muzzleTransform.position;
            Projectile projectile = projectileGO.GetComponent<Projectile>();
            projectile.IntiailizeProjectile(MouseUtils.Instance.GetMouseWorldPosition(), GetStats().projectileSpeed, GetStats().baseDamage);
            this.bulletsLeft--;
        }
    }
}