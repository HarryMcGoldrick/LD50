using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetatchOnDeath : MonoBehaviour
{
    public GameObject[] gameObjectsToDetatch;

    void Start()
    {
        GetComponent<Damagable>().OnBeforeDestroy.AddListener(Detatch);
    }

    private void Detatch()
    {
        for (int i = 0; i < gameObjectsToDetatch.Length; i++)
        {
            gameObjectsToDetatch[i].transform.parent = null;
        }
    }
}
