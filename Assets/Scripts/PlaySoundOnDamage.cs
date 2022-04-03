using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDamage : MonoBehaviour
{
    public AudioClips sound;

    private void Start()
    {
        GetComponent<Damagable>().OnDamageTaken.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlayLocalOneShot(sound);
    }
}
