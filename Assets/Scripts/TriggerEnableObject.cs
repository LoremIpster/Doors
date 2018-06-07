using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableObject : MonoBehaviour {

    [SerializeField]
    GameObject target;

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
        if (coll.tag == "Player")
            target.SetActive(true);
	}
}
