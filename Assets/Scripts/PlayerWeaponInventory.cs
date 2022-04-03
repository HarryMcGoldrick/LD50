using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeaponInventory : MonoBehaviour
{
    public List<BaseGun> equippedWeapons;
    public Dictionary<string, int> gunCountDictionary = new Dictionary<string, int>();
    public UnityEvent<BaseGun> OnWeaponEquip = new UnityEvent<BaseGun>();


    private void Start()
    {
        for (int i = 0; i < equippedWeapons.Count; i++)
        {
            equippedWeapons[i] = Instantiate(equippedWeapons[i]);
        }
        gunCountDictionary.Clear();
    }

    private void Update()
    {
        HandleWeapon();
    }

    public void EquipWeapon(BaseGun gun)
    {
        BaseGun clonedGun = Instantiate(gun);
        this.equippedWeapons.Add(clonedGun);
        AddGunToCountDictionary(gun);
        OnWeaponEquip.Invoke(clonedGun);
    }

    private void HandleWeapon()
    {
        for (int i = 0; i < equippedWeapons.Count; i++)
        {
            equippedWeapons[i].TryFireWeapon();
        }
    }

    public int GetGunCount(BaseGun gun)
    {
        if(gunCountDictionary.TryGetValue(gun.displayName , out int count))
        {
            return count;
        } else
        {
            return 0;
        }
    }

    public void AddGunToCountDictionary(BaseGun gun)
    {
        if (gunCountDictionary.ContainsKey(gun.displayName))
        {
            gunCountDictionary[gun.displayName] += 1;
        } else
        {
            gunCountDictionary.Add(gun.displayName, 1);
        }
    }
}
