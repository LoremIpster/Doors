using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioEventType { oneShotSound, SoundFade, RTPC }

[ExecuteInEditMode, RequireComponent(typeof(BoxCollider)), RequireComponent(typeof(AudioSource))]
public class GenericAudioTrigger : MonoBehaviour
{

    [SerializeField]
    string m_eventName;
    AudioSource m_audioSource;
    [SerializeField]
    AudioClip clip;
    [Header("Trigger Parameters")]
    public float m_size;
    BoxCollider m_box;


    //What kind of Audio Event?
    [SerializeField, Header("Audio Parameter")]
    AudioEventType m_audioEventType;

    [SerializeField]
    AudioClip m_clip;
    [SerializeField]
    AnimationCurve m_audioCurve;
    [Range(.1f, 5f), SerializeField]
    float m_lerpDuration;


    private void Awake()
    {
        m_box = GetComponent<BoxCollider>();
        m_audioSource = GetComponent<AudioSource>();
        m_box.isTrigger = true;

    }

    #region Odin Stuff
    //Utils
    bool IsOneShot()
    {
        return m_audioEventType == AudioEventType.oneShotSound;
    }

    bool IsFade()
    {
        return m_audioEventType == AudioEventType.SoundFade;
    }

    #endregion

    // Trigger enter
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            switch (m_audioEventType)
            {
                case AudioEventType.oneShotSound:
                    PlaySound();
                    break;
                case AudioEventType.SoundFade:
                    FadeSound();
                    break;
                case AudioEventType.RTPC:
                    LerpRTPC();
                    break;

            }
        }
    }

    #region Audio Methods
    private void PlaySound()
    {
        StartCoroutine(LerpAudio());
    }

    void FadeSound()
    {
        StartCoroutine(LerpAudio());
    }

    void LerpRTPC()
    {
        Debug.LogError("WWISE HASN'T BEEN PLUGGED YET SO DON'T USE RTPC");
    }

    #endregion

    //Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(.2f, .2f, .2f, .2f);
        Gizmos.DrawCube(transform.position, Vector3.one * m_size);
        m_box.size = new Vector3(m_size, m_size, m_size);
    }


    #region Waiting for Wwise
    IEnumerator LerpAudio()
    {
        float elapsed = 0;
        float initialVolume = m_audioCurve.Evaluate(0);

        //If the audio is muted :: it's a fade in
        if (initialVolume == 0)
        {
            m_audioSource.clip = clip;
            m_audioSource.Play();
        }

        while (elapsed <= m_lerpDuration)
        {
            m_audioSource.volume = m_audioCurve.Evaluate(elapsed / m_lerpDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (m_audioSource.volume == 0)
        {
            m_audioSource.Stop();
        }
    }

    #endregion
}
