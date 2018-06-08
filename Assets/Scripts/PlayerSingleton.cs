using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.ImageEffects;
public class PlayerSingleton : MonoBehaviour
{
    [SerializeField, Header("Lerp Parameters")]
    AnimationCurve m_easyInCurve;
    [Range(.1f, 30f), SerializeField]
    float m_lerpDuration;
    Vector3 initialPosition = new Vector3(0f, 1f, 3.5f);
    public static PlayerSingleton s_player;
    public bool m_loadedOnce = false;
    // Use this for initialization
    void Awake()
    {
        if (s_player == null)
            s_player = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        StartCoroutine(FadeInLines());

    }

    IEnumerator FadeInLines()
    {
        EdgeDetectionColor edgeDetection = Camera.main.GetComponent<EdgeDetectionColor>();
        float elapsed = 0;
        Color initialColor = edgeDetection.edgesColor;
        while (elapsed <= m_lerpDuration)
        {
            float step = m_easyInCurve.Evaluate(elapsed / m_lerpDuration);
            edgeDetection.edgesColor = Color.Lerp(initialColor, Color.white, step);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void SceneLoaded()
    {
        if (m_loadedOnce)
            transform.position = initialPosition;
        else
            m_loadedOnce = true;
    }
}
