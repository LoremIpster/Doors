using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


[ExecuteInEditMode, RequireComponent(typeof(BoxCollider))]
public class EdgeFading : MonoBehaviour {

    [Range(.1f, 30f), SerializeField]
    float m_lerpDuration;
    EdgeDetectionColor edgeDetection;
    BoxCollider m_box;
    [SerializeField, Header("Lerp Parameters")]
    AnimationCurve m_easyInCurve;


    private void Awake()
    {
        m_box = GetComponent<BoxCollider>();
        edgeDetection = Camera.main.GetComponent<EdgeDetectionColor>();
        m_box.isTrigger = true;

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            StartCoroutine(Lerp());
        }
    }

    IEnumerator Lerp()
    {
        float elapsed = 0;
        Color initialColor = edgeDetection.edgesColor;
        while (elapsed <= m_lerpDuration)
        {
            float step = m_easyInCurve.Evaluate(elapsed / m_lerpDuration);
            edgeDetection.edgesColor = Color.Lerp(initialColor, edgeDetection.edgesOnlyBgColor, step);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
