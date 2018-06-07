using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
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

    }

    public void SceneLoaded()
    {
        if (m_loadedOnce)
            transform.position = initialPosition;
        else
            m_loadedOnce = true;
    }
}
