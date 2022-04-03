using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDamage : MonoBehaviour
{
    public AudioClips sound;
    public AudioSource source;
    public bool localSource;

    private void Start()
    {
        GetComponent<Damagable>().OnDamageTaken.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        if (localSource)
        {
            AudioManager.Instance.PlayLocalOneShot(sound);
        } else
        {
            AudioManager.Instance.PlayOneShot(sound, source);
        }
    }
}
