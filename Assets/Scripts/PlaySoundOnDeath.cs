using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDeath : MonoBehaviour
{
    public AudioClips sound;
    public AudioSource source;
    public bool localSource;

    private void Start()
    {
        GetComponent<Damagable>().OnLethalDamageTaken.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (localSource || source == null)
        {
            AudioManager.Instance.PlayLocalOneShot(sound);
        }
        else
        {
            AudioManager.Instance.PlayOneShot(sound, source);
        }
    }
}
