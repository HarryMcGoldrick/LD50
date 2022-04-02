using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool destroyOnDeath = true;

    [HideInInspector] public UnityEvent OnDamageTaken = new UnityEvent();
    [HideInInspector] public UnityEvent OnBeforeDestroy = new UnityEvent();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void InflictDamage(float damage, Vector3 hitPoint)
    {
        Debug.Log("Inflicting Damage: " + damage);
        //DamageTextManager.Instance.SpawnDamageText(damage, hitPoint);
        this.currentHealth -= damage;
        OnDamageTaken.Invoke();

        if (destroyOnDeath && this.currentHealth <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        OnBeforeDestroy.Invoke();
        Debug.Log("Destroying");
        Destroy(this.gameObject);
    }
}
