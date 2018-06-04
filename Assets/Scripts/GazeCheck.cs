using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCheck : MonoBehaviour {

    [HideInInspector]
    public bool isVisible;

    private void OnBecameVisible()
    {
        //print("VISIBLE");
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        //print("INVISIBLE");
        isVisible = false;
    }
}
