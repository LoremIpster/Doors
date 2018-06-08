using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour {
    
	// Use this for initialization
	public void DoorPlaySound () {
        GetComponent<AudioSource>().Play();	
	}
	
}
