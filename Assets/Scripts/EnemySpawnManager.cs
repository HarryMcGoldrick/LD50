using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    public EnemyPrefabSpawner[] prefabSpawners;

    public SpawnWave[] waves;
    public AnimationCurve spawnCurve;
    public float minSpawnRate;
    public float updateRate = 1f;

    public int currentSpawnedAmount;
    public int currentWave;

    [Header("Debug")]
    public float spawnRate;
    private float updateRateTimer;
    private float spawnRateTimer;
    private float timeSinceLastWave;
  
    private void Update()
    {
        if (timeSinceLastWave >= waves[currentWave].duration && currentWave < waves.Length-1)
        {
            currentWave++;
            timeSinceLastWave = 0;
        }

        timeSinceLastWave += Time.deltaTime;
        updateRateTimer -= Time.deltaTime;
        spawnRateTimer -= Time.deltaTime;
        if (updateRateTimer <= 0)
        {
            UpdateSpawnRate();
        }


        if (waves[currentWave].minAmount > currentSpawnedAmount)
        {
            int amountToSpawn = (waves[currentWave].minAmount - currentSpawnedAmount);
            for (int i = 0; i < amountToSpawn; i++)
            {
                SpawnEnemy();
            }
        }
        else if (waves[currentWave].maxAmount < currentWave)
        {
            if (spawnRateTimer <= 0)
            {
                SpawnEnemy();
                spawnRateTimer = spawnRate;
            }
        }
    }


    public void SpawnEnemy()
    {
        KeyValuePairSerialized<GameObject, float> enemySpawn = waves[currentWave].enemiesToSpawn[Random.Range(0, waves[currentWave].enemiesToSpawn.Length)];
        if (enemySpawn.Value > Random.value)
        {
            prefabSpawners[Random.Range(0, prefabSpawners.Length)].SpawnEnemy(enemySpawn.Key);
            currentSpawnedAmount++;
        }
    }

    public void UpdateSpawnRate()
    {
        float timePercentage = Mathf.Clamp01(timeSinceLastWave / waves[currentWave].duration);
        float curveVal = spawnCurve.Evaluate(timePercentage);
        if (currentWave < waves.Length-1)
        {
            spawnRate = Mathf.Lerp(waves[currentWave].spawnRate, waves[currentWave + 1].spawnRate, curveVal);
        } else
        {
            spawnRate = Mathf.Lerp(waves[currentWave].spawnRate, 0.1f, curveVal);
        }
    }

    //public GameObject GetEnemyToSpawn()
    //{

    //}
}

[System.Serializable]
public struct SpawnWave
{
    public int duration;
    public int minAmount;
    public int maxAmount;
    public float spawnRate;
    public KeyValuePairSerialized<GameObject, float>[] enemiesToSpawn;
}
