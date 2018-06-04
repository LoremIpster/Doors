using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOutside : MonoBehaviour {

    [HideInInspector]
    public bool isOutside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //print("EXIT");
            isOutside = true;
        }
    }
}
