using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOnDeath : MonoBehaviour
{
    public GameObject drop;

    private void Start()
    {
        GetComponent<Damagable>().OnBeforeDestroy.AddListener(OnDeath);
    }

    private void OnDeath()
    {
            if (GlobalLootManager.Quitting)
                return;
            GameObject dropGO = Instantiate(drop);
            dropGO.transform.position = this.transform.position;
            ScoreManager.Instance.UpdateScore();
            EnemySpawnManager.Instance.currentSpawnedAmount--;
    }

}
