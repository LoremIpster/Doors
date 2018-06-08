using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{

    public GameObject anchorL;
    public GameObject anchorC;
    public GameObject anchorR;

    [Space]

    public GameObject innerVolumeL;
    public GameObject innerVolumeC;
    public GameObject innerVolumeR;

    [Space]

    public GameObject outerVolumeL;
    public GameObject outerVolumeC;
    public GameObject outerVolumeR;

    [Space]

    private GameObject room0, room1, room2, room3, room4, room5, room6, room7, room8, room9;
    private GameObject dock;

    private bool spawningDone;
    private bool walkthroughComplete;
    private GameObject nextRoom;

    private bool goingL, goingC, goingR;

    private PositionCheck innerPositionCheckL, outerPositionCheckL;

    private PositionCheck innerPositionCheckC, outerPositionCheckC;

    private PositionCheck innerPositionCheckR, outerPositionCheckR;

    private GameObject managerGO;
    private Manager managerScript;

	void Start ()
    {
        dock = GameObject.Find("Dock");

        // TO BE TURNED INTO AN ARRAY
        room0 = GameObject.Find("Start");
        room1 = GameObject.Find("World");
        room2 = GameObject.Find("RoomLost4");
        room3 = GameObject.Find("RoomLost3");
        room4 = GameObject.Find("RoomLost2");
        room5 = GameObject.Find("RoomLost1");
        room6 = GameObject.Find("RoomLost5");
        room7 = GameObject.Find("RoomRepeat");
        room8 = GameObject.Find("Stairway");

        // ARRAAAAAAY
        room1.transform.position = dock.transform.position;
        room2.transform.position = dock.transform.position;
        room3.transform.position = dock.transform.position;
        room4.transform.position = dock.transform.position;
        room5.transform.position = dock.transform.position;
        room6.transform.position = dock.transform.position;
        room7.transform.position = dock.transform.position;
        room8.transform.position = dock.transform.position;

        spawningDone = false;
        nextRoom = room0;

        managerGO =  GameObject.Find("Manager");
        managerScript = managerGO.GetComponent<Manager>();

        innerPositionCheckL = innerVolumeL.GetComponent<PositionCheck>();
        outerPositionCheckL = outerVolumeL.GetComponent<PositionCheck>();

        innerPositionCheckC = innerVolumeC.GetComponent<PositionCheck>();
        outerPositionCheckC = outerVolumeC.GetComponent<PositionCheck>();

        innerPositionCheckR = innerVolumeR.GetComponent<PositionCheck>();
        outerPositionCheckR = outerVolumeR.GetComponent<PositionCheck>();
	}

	void Update ()
    {
        if(!spawningDone)
        {
            if (innerPositionCheckL.isInside)
            {
                ActivateRoom(anchorL);
            }
            else if (innerPositionCheckC.isInside)
            {
                ActivateRoom(anchorC);
            }
            else if (innerPositionCheckR.isInside)
            {
                ActivateRoom(anchorR);
            }
        }else if (outerPositionCheckL.isInside || outerPositionCheckC.isInside || outerPositionCheckR.isInside)
        {
            DeactivateRoom();
        }
	}

    void ActivateRoom(GameObject anchor)
    {
        if (walkthroughComplete)
        {
            ResetWalkthrough();
        }

        CheckRoomNumber();
        nextRoom.SetActive(true);
        nextRoom.transform.position = anchor.transform.position;
        nextRoom.transform.rotation = anchor.transform.rotation;
        spawningDone = true;
    }

    void CheckRoomNumber()
    {
        managerScript.roomNumber++;
        switch (managerScript.roomNumber)
        {
            case 0:
                nextRoom = room0;
                break;
            case 1:
                nextRoom = room1;
                break;
            case 2:
                nextRoom = room2;
                break;
            case 3:
                nextRoom = room3;
                break;
            case 4:
                nextRoom = room4;
                break;
            case 5:
                nextRoom = room5;
                break;
            case 6:
                nextRoom = room6;
                break;
            case 7:
                nextRoom = room7;
                break;
            case 8:
                nextRoom = room8;
                ResetWalkthrough();
                break;
        }
    }

    void ResetWalkthrough()
    {
        managerScript.roomNumber = -1;
        managerScript.beat = 0;
    }

    void DeactivateRoom()
    {
        gameObject.transform.position = dock.transform.position;
    }
}
