using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGun : ScriptableObject
{
    public Sprite sprite;
    public string displayName;
    public string displayDescription;
    [HideInInspector] public Transform muzzleTransform;
    [SerializeField] private GunStats baseStats;
    public int bulletsLeft;

    [Header("Audio")]
    public AudioClips shootSound;

    private bool hasFireRate = true;
    private bool isReloading = false;


    private void OnEnable()
    {
        hasFireRate = true;
        isReloading = false;
        Reload();
        
        if (PlayerUtils.Instance.GetWeaponInventory().GetGunCount(this) > AudioManager.Instance.maxGunCountSound)
            shootSound = null;
    }

    protected abstract void Fire();

    private void Reload()
    {
        this.bulletsLeft = GetStats().maxMagazineCapacity;
    }

    public void TryFireWeapon()
    {
        if (isReloading)
            return;

        if (CheckForReload())
        {
            PlayerUtils.Instance.StartCoroutine(ReloadRoutine());
        }
        else if (hasFireRate)
        {
            PlayerUtils.Instance.StartCoroutine(FireRateRoutine());
            Fire();
            this.bulletsLeft--;
        }
    }

    public GunStats GetStats()
    {
        return baseStats;
    }

    IEnumerator FireRateRoutine()
    {
        hasFireRate = false;
        yield return new WaitForSeconds(this.GetStats().fireRate);
        hasFireRate = true;
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(GetStats().reloadDuration);
        this.Reload();
        isReloading = false;
    }


    private bool CheckForReload()
    {
        return this.bulletsLeft <= 0;
    }
}

[System.Serializable]
public struct GunStats
{
    public float fireRate;
    public float damage;
    public int maxMagazineCapacity;
    public int projectileSpeed;
    public float reloadDuration;
    public float knockbackForce;
    public float bulletScale;
}