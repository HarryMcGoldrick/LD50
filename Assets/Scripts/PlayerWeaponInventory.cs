using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeaponInventory : MonoBehaviour
{
    public List<BaseGun> equippedWeapons;

    //public static UnityEvent<BaseGun> OnWeaponFire = new UnityEvent<BaseGun>();
    //public static UnityEvent<BaseGun> OnWeaponReloadStart = new UnityEvent<BaseGun>();
    //public static UnityEvent<BaseGun> OnWeaponReloadEnd = new UnityEvent<BaseGun>();

    public UnityEvent<BaseGun> OnWeaponEquip = new UnityEvent<BaseGun>();


    //private RigidbodyKnockback knockbackHandler;



    private void Start()
    {
        for (int i = 0; i < equippedWeapons.Count; i++)
        {
            equippedWeapons[i] = Instantiate(equippedWeapons[i]);
        }

        //UpdateWeaponVisuals();

        //knockbackHandler = this.transform.root.GetComponent<RigidbodyKnockback>();
        //UIPlayerHudManager.Instance.UpdateAmmoDisplay(equippedWeapon);
    }

    private void Update()
    {
        HandleWeapon();
    }

    public void EquipWeapon(BaseGun gun)
    {
        BaseGun clonedGun = Instantiate(gun);
        this.equippedWeapons.Add(clonedGun);
        OnWeaponEquip.Invoke(clonedGun);
    }

    private void HandleWeapon()
    {
        for (int i = 0; i < equippedWeapons.Count; i++)
        {
            equippedWeapons[i].TryFireWeapon();
        }
    }
}
