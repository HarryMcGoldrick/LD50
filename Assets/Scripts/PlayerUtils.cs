using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtils : Singleton<PlayerUtils>
{
    private GameObject player;
    private AudioSource playerAudioSource;
    private PlayerWeaponInventory weaponInventory;

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

    public AudioSource GetPlayerAudioSource()
    {
        if (playerAudioSource == null)
            playerAudioSource = GetPlayerGameObject().GetComponent<AudioSource>();
        return playerAudioSource;
    }

    public PlayerWeaponInventory GetWeaponInventory()
    {
        if (weaponInventory == null)
            weaponInventory = GetPlayerGameObject().GetComponent<PlayerWeaponInventory>();
        return weaponInventory;
    }
}
