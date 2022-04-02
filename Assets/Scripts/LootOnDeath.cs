using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOnDeath : MonoBehaviour
{
    //public GameObject spawnPrefab;

    private void Start()
    {
        GetComponent<Damagable>().OnBeforeDestroy.AddListener(() => GlobalLootManager.Instance.RollDropTable(this.transform.position));

        // TODO REMOVE -TEMP-
        GetComponent<Damagable>().OnBeforeDestroy.AddListener(() => ScoreManager.Instance.UpdateScore());
    }

    //private void SpawnPrefabOnDeath()
    //{
    //    GameObject GO = Instantiate(this.spawnPrefab);
    //    GO.transform.position = this.transform.position;
    //}
}
