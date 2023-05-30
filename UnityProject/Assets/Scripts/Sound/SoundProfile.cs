using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundProfile")]
public class SoundProfile : ScriptableObject
{
    public AudioClip[] clips;
    public AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    public float volume = 1;
    public float pitch = 1;
    public float pitchVariance = 0;
}
