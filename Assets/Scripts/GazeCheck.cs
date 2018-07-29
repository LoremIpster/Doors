using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCheck : MonoBehaviour {

    [HideInInspector]
    public bool isVisible;


    private void OnBecameVisible()
    {
        isVisible = true;
        //print("looked at");
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
        //print("not looked at");
    }
}
