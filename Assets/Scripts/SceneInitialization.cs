using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitialization : MonoBehaviour {

	// Use this for initialization
    IEnumerator Start () {
        yield return null;
        PlayerSingleton.s_player.SceneLoaded();

    }
	}
