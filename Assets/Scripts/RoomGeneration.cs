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

    public GameObject room0;
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;

    private int roomNumber;
    private bool spawningDone;
    private GameObject nextRoom;

    private bool goingL;
    private bool goingC;
    private bool goingR;

    private PositionCheck innerPositionCheckL;
    private PositionCheck outerPositionCheckL;

    private PositionCheck innerPositionCheckC;
    private PositionCheck outerPositionCheckC;

    private PositionCheck innerPositionCheckR;
    private PositionCheck outerPositionCheckR;

    private GameObject manager;
    private Manager managerScript;

	void Start ()
    {
        room0 = Resources.Load("Prefabs/Rooms/RoomStandard") as GameObject;
        room1 = Resources.Load("Prefabs/Rooms/Room_3E_S") as GameObject;
        room2 = Resources.Load("Prefabs/Rooms/Room_3E_L") as GameObject;
        room3 = Resources.Load("Prefabs/Rooms/Room_3E_XL") as GameObject;

        spawningDone = false;
        nextRoom = room0;

        manager =  GameObject.Find("Manager");
        managerScript = manager.GetComponent<Manager>();

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
                SpawnNewRoom(anchorL);
            }
            else if (innerPositionCheckC.isInside)
            {
                SpawnNewRoom(anchorC);
            }
            else if (innerPositionCheckR.isInside)
            {
                SpawnNewRoom(anchorR);
            }
        }else if (outerPositionCheckL.isInside || outerPositionCheckC.isInside || outerPositionCheckR.isInside)
        {
            UnSpawnRoom();
        }
	}

    void SpawnNewRoom(GameObject anchor)
    {
        CheckRoomNumber();
        Instantiate(nextRoom, anchor.transform.position, anchor.transform.rotation);
        spawningDone = true;
    }

    void CheckRoomNumber()
    {
        managerScript.roomNumber++;
        //print(managerScript.roomNumber);
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
                managerScript.roomNumber = 0;
                break;
        }
    }

    void UnSpawnRoom()
    {
        gameObject.SetActive(false);
    }
}
