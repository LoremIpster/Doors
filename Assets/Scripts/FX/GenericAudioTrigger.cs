using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioEventType { oneShotSound, SoundActivation, SoundDeactivation, RTPCEvent }

[ExecuteInEditMode, RequireComponent(typeof(BoxCollider)), RequireComponent(typeof(AudioSource))]
public class GenericAudioTrigger : MonoBehaviour {
    [SerializeField]
    AudioEventType m_audioEventType;
    [SerializeField]
    string m_eventName;
    AudioSource m_audioSource;
    [Header("Trigger Parameters")]
    public float m_size;
    BoxCollider m_box;
    [SerializeField]
    AnimationCurve m_easyInCurve;
    [Range(.1f, 5f), SerializeField]
    float m_lerpDuration;

    private void Awake()
    {
        m_box = GetComponent<BoxCollider>();
        m_audioSource = GetComponent<AudioSource>();
        m_box.isTrigger = true;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.2f,.2f,.2f,.2f);
        Gizmos.DrawCube(transform.position, Vector3.one * m_size);
        m_box.size = new Vector3(m_size, m_size, m_size);
    }


    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            //StartCoroutine(Lerp());
        }
    }
    /*
    IEnumerator Lerp()
    {
        float elapsed = 0;
        Color initialColor = edgeDetection.edgesOnlyBgColor;
        while (elapsed <= m_lerpDuration)
        {
            float step = m_easyInCurve.Evaluate(elapsed / m_lerpDuration);
            edgeDetection.edgesOnlyBgColor = Color.Lerp(initialColor, m_newColor, step);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }*/
}
