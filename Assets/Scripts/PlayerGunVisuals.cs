using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunVisuals : MonoBehaviour
{
    public Transform gunVisualsParent;
    public int gunsPerCircle;
    public float radius;
    //public float radiusIncrement;

    private PlayerWeaponInventory weaponInventory;
    private List<Transform> gunVisualTransforms = new List<Transform>();

    private void Start()
    {
        weaponInventory = GetComponent<PlayerWeaponInventory>();
        weaponInventory.OnWeaponEquip.AddListener(this.AddGunVisual);
    }



    public void AddGunVisual(BaseGun gun)
    {
        GameObject emptyGO = new GameObject(gun.displayName);
        gunVisualTransforms.Add(emptyGO.transform);
        emptyGO.transform.SetParent(gunVisualsParent.transform, false);
        SpriteRenderer spriteRenderer = emptyGO.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = gun.sprite;
        gun.muzzleTransform = emptyGO.transform;
        RepositionAllGuns();
    }

    private void RepositionAllGuns()
    {
        int points = gunVisualTransforms.Count;
        Vector2 center = gunVisualsParent.transform.position;
        float slice = 2 * Mathf.PI / points;
        for (int i = 0; i < points; i++)
        {
            gunVisualTransforms[i].position = GetCirclePosition(center, radius, i);
        }
    }

    private Vector2 GetCirclePosition(Vector2 CenterPosition, float radius, int count)
    {
        float x = radius * Mathf.Cos(count) + CenterPosition.x;
        float y = radius * Mathf.Sin(count) + CenterPosition.y;
        return new Vector2(x, y);
    }
}
