using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class GunPickup : MonoBehaviour
{
    public BaseGun baseGun;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = baseGun.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerWeaponInventory>().EquipWeapon(baseGun);
            Destroy(this.gameObject);
        }
    }
}
