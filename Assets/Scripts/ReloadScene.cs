using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour {

    private bool sceneAllowed = false;

    IEnumerator Start()
    {
        sceneAllowed = false;
        //        Application.backgroundLoadingPriority = ThreadPriority.Low;
        yield return new WaitForSeconds(10f);
        StartCoroutine(ReloadSceneAsync());
    }

    private IEnumerator ReloadSceneAsync()
    {
        var async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;
        while (!sceneAllowed)
            yield return new WaitForSeconds(2.5f);
        async.allowSceneActivation = true;
    }

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
        if (coll.CompareTag("Player"))
            sceneAllowed = true;
	}
}
