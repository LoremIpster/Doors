using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
        if (coll.tag == "Player")
            SceneManager.LoadScene(0);
	}
}
