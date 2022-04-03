using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : BasePickup
{
    public BaseGun baseGun;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = baseGun.sprite;
    }


    protected override void ConsumePickup()
    {
        PlayerUtils.Instance.GetWeaponInventory().EquipWeapon(baseGun);
        Destroy(this.gameObject);
    }
}
