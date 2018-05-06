using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerObjectActivation : MonoBehaviour
{

    [SerializeField]
    GameObject m_objToDestroy;

    // Use this for initialization
    void OnTriggerEnter()
    {
        Destroy(m_objToDestroy);
    }
}
