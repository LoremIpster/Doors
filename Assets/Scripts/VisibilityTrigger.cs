using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityTrigger : MonoBehaviour
{

    [SerializeField]
    float m_triggerTime;
    Coroutine countdown;
    // Update is called once per frame
    void OnBecameVisible()
    {
        countdown = StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float elapsed = 0;
        while (elapsed < m_triggerTime)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        Trigger();
    }

    protected virtual void Trigger()
    {
        StopCoroutine(countdown);
        countdown = null;
    }

    private void OnBecameInvisible()
    {
        m_triggerTime = 0;
    }
}
