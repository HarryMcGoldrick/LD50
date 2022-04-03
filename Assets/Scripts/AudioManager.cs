using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource playerSource;
    public int maxGunCountSound = 5;

    public void PlayLocalOneShot(AudioClips sound)
    {
        if (playerSource == null)
            playerSource = PlayerUtils.Instance.GetPlayerAudioSource();
        PlayOneShot(sound, playerSource);
    }

    public void PlayOneShot(AudioClips sound, AudioSource source)
    {
        source.pitch = sound.GetPitch();
        source.PlayOneShot(sound.GetNextClip(), sound.volume);
    }

    public void PlayContinuedSound(AudioSource source, AudioClips sound)
    {
        if (source.clip == null)
            source.clip = sound.GetNextClip();
        source.volume = sound.volume;

        if (source.isPlaying)
        {
            return;
        }

        source.Play();
    }

    public void PauseContinuedSound(AudioSource source)
    {
        source.Pause();
    }

    public void MuteAudio(bool val)
    {
        this.playerSource.mute = val;
    }
}
