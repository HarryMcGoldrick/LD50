using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : Singleton<PlayerUtils>
{
    private GameObject player;
    private AudioSource playerAudioSource;

    public GameObject GetPlayerGameObject()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }

    public Vector3 GetPlayerPosition()
    {
        return GetPlayerGameObject().transform.position;
    }

    public bool IsPlayerObject(GameObject gameObject)
    {
        return gameObject.transform.root.CompareTag("Player");
    }
}
