using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class DoorSound : MonoBehaviour {

    [SerializeField]
    const string c_EVENTNAME = "SFX_DOOR_OPEN";

	// Use this for initialization
	public void DoorPlaySound () {
        AkSoundEngine.PostEvent(c_EVENTNAME, gameObject);
	}
	
}
