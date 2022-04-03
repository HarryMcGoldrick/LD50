using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDestroy : MonoBehaviour
{
    public AudioClips sound;

    private void OnDestroy()
    {
        if (!AudioManager.Quitting)
            AudioManager.Instance.PlayLocalOneShot(sound);
    }
}
