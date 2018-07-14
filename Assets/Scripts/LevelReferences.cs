using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReferences : MonoBehaviour {

    public static LevelReferences s_references;

    //Level References
    public GameObject room0, room1, room2, room3, room4, room5, room6, room7, room8, room9, dock;

    // Use this for initialization
    void Awake () {
        if (s_references == null)
            s_references = this;
        else
            Destroy(gameObject);
	}


    private void Start()
    {

        // Set room References (and only once this time)
        room1.transform.position = dock.transform.position;
        room2.transform.position = dock.transform.position;
        room3.transform.position = dock.transform.position;
        room4.transform.position = dock.transform.position;
        room5.transform.position = dock.transform.position;
        room6.transform.position = dock.transform.position;
        room7.transform.position = dock.transform.position;
        room8.transform.position = dock.transform.position;
    }

}
