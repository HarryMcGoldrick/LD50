using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource[] playerSfxSources;
    public int maxGunCountSound = 5;

    public Queue<AudioClips> soundQueue = new Queue<AudioClips>();

    public void PlayLocalOneShot(AudioClips sound)
    {
        soundQueue.Enqueue(sound);
    }

    private void PlayOneShot(AudioClips sound, AudioSource source)
    {
        source.pitch = sound.GetPitch();
        source.PlayOneShot(sound.GetNextClip(), sound.volume);
    }

    private void Update()
    {
        for (int i = 0; i < playerSfxSources.Length; i++)
        {
            if (soundQueue.Count > 0)
                PlayOneShot(soundQueue.Dequeue(), playerSfxSources[i]);
        }
    }


    //public void PlayContinuedSound(AudioSource source, AudioClips sound)
    //{
    //    if (source.clip == null)
    //        source.clip = sound.GetNextClip();
    //    source.volume = sound.volume;

    //    if (source.isPlaying)
    //    {
    //        return;
    //    }

    //    source.Play();
    //}

    //public void PauseContinuedSound(AudioSource source)
    //{
    //    source.Pause();
    //}

    public void MuteAudio(bool val)
    {
        for (int i = 0; i < playerSfxSources.Length; i++)
        {
            playerSfxSources[i].mute = val;
        }
    }
}
