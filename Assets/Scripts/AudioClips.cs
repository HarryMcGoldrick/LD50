using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips")]
public class AudioClips : ScriptableObject
{
    public AudioClip[] clips;
    public float volume;
    public float minPitch;
    public float maxPitch;
    public SoundPitchMode pitchMode;
    public SoundClipMode clipMode;

    [Header("Pitch Increments")]
    public float pitchIncrement;
    public float resetTime;

    private float currentPitch;
    private int currentSoundIndex = 0;
    private float timeAtLastClip = 0;
    public float maxLength;

    public float GetPitch()
    {
        if (pitchMode == SoundPitchMode.INCREASE)
        {
            if (Time.realtimeSinceStartup - timeAtLastClip > resetTime)
                currentPitch = minPitch;

            if (currentPitch + pitchIncrement >= maxPitch)
                currentPitch = maxPitch;
            else
                currentPitch += pitchIncrement;
            return currentPitch;
        }
        else
        {
            return Random.Range(minPitch, maxPitch);
        }
    }

    public AudioClip GetNextClip()
    {
        timeAtLastClip = Time.realtimeSinceStartup;
        if (clipMode == SoundClipMode.SEQUENTIAL)
        {
            return GetNextSoundInArray();
        }
        else
        {
            return GetRandomSoundInArray();
        }
    }

    private AudioClip GetRandomSoundInArray()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    private AudioClip GetNextSoundInArray()
    {
        int soundIndex = currentSoundIndex;
        if (currentSoundIndex + 1 >= clips.Length)
            currentSoundIndex = 0;
        else
            currentSoundIndex++;
        return clips[soundIndex];
    }

    private float CalculateMaxLength()
    {
        float average = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            average += clips[i].length;
        }
        return average / clips.Length;
    }

    private void OnEnable()
    {
        this.maxLength = CalculateMaxLength();
    }
}

public enum SoundClipMode
{
    RANDOM,
    SEQUENTIAL,
}

public enum SoundPitchMode
{
    RANDOM,
    INCREASE,
}
