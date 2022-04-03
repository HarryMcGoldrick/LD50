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
        GameStateManager.Instance.SwitchState(GameState.FREEZE);
        UIStateManager.Instance.SwitchState(UIState.DEATH);
    }
}
