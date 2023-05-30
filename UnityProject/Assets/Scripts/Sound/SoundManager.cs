using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject source;

    static SoundManager manager;

    public static SoundManager Get()
    {
        return manager;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = this;
    }

    public void playSound(SoundProfile profile)
    {
        playSound(profile, Camera.main.transform.position);
    }
    public void playSound(SoundProfile profile, Vector3 location)
    {
        playSound(profile, location, 1);

    }
    public void playSound(SoundProfile profile, Vector3 location, float volume)
    {
        GameObject copy = GameObject.Instantiate(source, Camera.main.transform);
        copy.GetComponent<SoundPlayer>().playSound(profile, location, volume);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
