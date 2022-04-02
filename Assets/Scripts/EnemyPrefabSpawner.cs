using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform parentTransform;
    public Vector2 spawnSize;

    //public float rate;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = EnemySpawnManager.Instance.GetSpawnRate();
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        GameObject GO = Instantiate(prefab);
        GO.transform.position = RandomPointInBounds(GetSpawnBounds());
        if (parentTransform != null)
            GO.transform.SetParent(parentTransform);
    }

    public static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

    private void OnDrawGizmosSelected()
    {
        Bounds bounds = GetSpawnBounds();
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }

    private Bounds GetSpawnBounds()
    {
        return new Bounds(this.transform.position, this.spawnSize);
    }
}


