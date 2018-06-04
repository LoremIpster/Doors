using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDisable : MonoBehaviour {
    
    private PositionCheck positionScript;
    private bool playerInside;
    Collider collider;

	void Start ()
    {
        positionScript = GetComponent<PositionCheck>();
        collider = GetComponent<MeshCollider>();
	}
	
	void Update ()
    {
        playerInside = positionScript.isInside;

        if(playerInside)
        {
            collider.enabled = false;
        }
	}



}
