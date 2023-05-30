using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    AudioSource source;
    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            GameObject.Destroy(gameObject);
        }

    }
    public void playSound(SoundProfile profile, Vector3 location, float volume)
    {
        source = GetComponent<AudioSource>();
        transform.position = location;

        source.pitch = profile.pitch + (-profile.pitchVariance / 2.0f + (Random.value * profile.pitchVariance));
        source.volume = profile.volume * volume;

        source.PlayOneShot(profile.GetRandomClip());

    }
}
