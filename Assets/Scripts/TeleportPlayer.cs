using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField]
    Transform target;

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.transform.position = target.position;
            Destroy(gameObject);
        }
    }
}
