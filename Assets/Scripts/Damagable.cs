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
    [HideInInspector] public UnityEvent OnLethalDamageTaken = new UnityEvent();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void InflictDamage(float damage, Vector3 hitPoint)
    {
        //DamageTextManager.Instance.SpawnDamageText(damage, hitPoint);
        this.currentHealth -= damage;
        OnDamageTaken.Invoke();

        if (this.currentHealth <= 0)
        {
            OnLethalDamageTaken.Invoke();
            if (destroyOnDeath)
                Destroy();
        }
    }

    public void Destroy()
    {
        OnBeforeDestroy.Invoke();
        Destroy(this.gameObject);
    }

    public void FullHeal()
    {
        this.currentHealth = maxHealth;
        OnDamageTaken.Invoke();
    }
}
