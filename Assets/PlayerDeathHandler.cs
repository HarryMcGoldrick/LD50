using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damagable))]
public class PlayerDeathHandler : MonoBehaviour
{
    private Damagable damagable;

    private void Start()
    {
        damagable = GetComponent<Damagable>();
        damagable.OnLethalDamageTaken.AddListener(HandleDeath);
    }

    private void HandleDeath()
    {
        Time.timeScale = 0.0f;
        UIDeathScreen.Instance.EnableDeathScreen();
    }
}
