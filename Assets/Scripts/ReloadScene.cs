using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour {
    static public ReloadScene s_instance;
    public bool sceneAllowed = false;
    [SerializeField]
    Image m_ovelay;
    IEnumerator Start()
    {
        s_instance = this;
        sceneAllowed = false;
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ReloadSceneAsync());
    }

    private IEnumerator ReloadSceneAsync()
    {
        var async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;
        while (!sceneAllowed)
            yield return new WaitForSeconds(2.5f);
        m_ovelay.CrossFadeAlpha(1, 1.8f, true);
        yield return new WaitForSeconds(10f);
        async.allowSceneActivation = true;
    }

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
        if (coll.CompareTag("Player"))
            sceneAllowed = true;
	}
}
