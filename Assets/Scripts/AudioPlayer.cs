using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    [SerializeField]
    string m_eventName;

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
            AkSoundEngine.PostEvent(m_eventName, gameObject);
        }
    }

}
