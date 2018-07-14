using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject BackCover;
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


    private bool spawningDone;
    private bool walkthroughComplete;
    private GameObject nextRoom;

    private bool goingL, goingC, goingR;

    private PositionCheck innerPositionCheckL, outerPositionCheckL;

    private PositionCheck innerPositionCheckC, outerPositionCheckC;

    private PositionCheck innerPositionCheckR, outerPositionCheckR;

    private GameObject managerGO;
    private Manager managerScript;

    void Start()
    {
        spawningDone = false;
        nextRoom = LevelReferences.s_references.room0;

        managerGO = GameObject.Find("Manager");
        managerScript = managerGO.GetComponent<Manager>();

        innerPositionCheckL = innerVolumeL.GetComponent<PositionCheck>();
        outerPositionCheckL = outerVolumeL.GetComponent<PositionCheck>();

        innerPositionCheckC = innerVolumeC.GetComponent<PositionCheck>();
        outerPositionCheckC = outerVolumeC.GetComponent<PositionCheck>();

        innerPositionCheckR = innerVolumeR.GetComponent<PositionCheck>();
        outerPositionCheckR = outerVolumeR.GetComponent<PositionCheck>();
    }

    void Update()
    {
        if (!spawningDone)
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
        }
        else if (outerPositionCheckL.isInside || outerPositionCheckC.isInside || outerPositionCheckR.isInside)
        {
            DeactivateRoom();
            if (BackCover != null)
                BackCover.SetActive(true);
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
                nextRoom = LevelReferences.s_references.room0;
                break;
            case 1:
                nextRoom = LevelReferences.s_references.room1;
                break;
            case 2:
                nextRoom = LevelReferences.s_references.room2;
                break;
            case 3:
                nextRoom = LevelReferences.s_references.room3;
                break;
            case 4:
                nextRoom = LevelReferences.s_references.room4;
                break;
            case 5:
                nextRoom = LevelReferences.s_references.room5;
                break;
            case 6:
                nextRoom = LevelReferences.s_references.room6;
                break;
            case 7:
                nextRoom = LevelReferences.s_references.room7;
                break;
            case 8:
                nextRoom = LevelReferences.s_references.room8;
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
        gameObject.transform.position = LevelReferences.s_references.dock.transform.position;
    }
}
