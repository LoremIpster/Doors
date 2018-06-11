using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    float volume;
    [SerializeField]
    public bool canPlayOnlyOnce;

    bool once = false;
    private void OnTriggerEnter(Collider other)
    {
        if (canPlayOnlyOnce && once)
            return;
        if (other.CompareTag("Player"))
        {
            once = true;
            source.Stop();
            source.clip = clip;
            source.volume = volume;
            source.Play();
        }
    }

}
