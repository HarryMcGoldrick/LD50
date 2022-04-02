using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    public AnimationCurve spawnCurve;

    public float minSpawnRate;
    public float maxRate;
    public float duration;
    public float updateRate;

    [Header("Debug")]
    public float spawnRate;
    private float timer;
  
    private void Update()
    {
        spawnRate = GetSpawnRate();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = updateRate;
            float timePercentage = Mathf.Clamp01(Time.timeSinceLevelLoad / duration);
            float curveVal = spawnCurve.Evaluate(timePercentage);
            spawnRate = Mathf.Lerp(maxRate, minSpawnRate, curveVal);
        }
    }


    public float GetSpawnRate()
    {
        return spawnRate;
    }
}
