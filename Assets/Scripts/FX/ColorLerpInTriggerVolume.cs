using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
[ExecuteInEditMode, RequireComponent(typeof(BoxCollider))]
public class ColorLerpInTriggerVolume : MonoBehaviour {

    public float m_size;
    public Color m_newColor = Color.red;
    BoxCollider m_box;
    EdgeDetectionColor edgeDetection;

    [Range(.1f, 5f), SerializeField]
    float m_lerpDuration;

    private void Awake()
    {
        m_box = GetComponent<BoxCollider>();
        edgeDetection = Camera.main.GetComponent<EdgeDetectionColor>();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(m_newColor.r, m_newColor.g, m_newColor.b, .2f);
        Gizmos.DrawCube(transform.position, Vector3.one * m_size);
        m_box.size = new Vector3(m_size, m_size, m_size);
    }
    

    // Update is called once per frame
    void OnTriggerEnter (Collider coll) {
        if (coll.tag == "Player")
        {
            StartCoroutine(Lerp());
        }
	}

    IEnumerator Lerp()
    {
        float elapsed = 0;
        while (elapsed <= m_lerpDuration)
        {

            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
