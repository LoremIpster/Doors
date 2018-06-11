using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour {
    [SerializeField]
    float duration, targetVolume;
    [SerializeField]
    AudioSource aS;
    [SerializeField]
    AnimationCurve m_curve;
    bool once;

    private void OnTriggerEnter(Collider other)
    {
        if (!once)
        {
            once = true;
            StartCoroutine(FadeSound());
        }
    }

    // Update is called once per frame
    IEnumerator FadeSound () {
        float initialVolume = aS.volume;
        float elapsed = 0;
        while (elapsed <= duration)
        {
            aS.volume = Mathf.Lerp(initialVolume, targetVolume,  m_curve.Evaluate(elapsed / duration));
            yield return null;
            elapsed += Time.deltaTime;
        }
	}
}
