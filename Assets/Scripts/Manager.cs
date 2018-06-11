using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    private bool nextLevel;
    private GameObject pawn;
    private PlayerData playerScript;
    private GazeCheck gazeScript;
    private PositionCheck positionScript;

    [HideInInspector]
    public int beat;

    [HideInInspector]
    public bool gazeOk;

    [HideInInspector]
    public bool positionOk;

    [HideInInspector]
    public float timeMoving;

    [HideInInspector]
    public int roomNumber;

    [Space]

    [Header("Beat 1")]
    public GameObject wallStart;
    public GameObject triggerStart;
    public GameObject doorCover;
    public GameObject door;

    [Space]

    [Header("Beat 2")]
    public GameObject doorDeadEnd;
    public GameObject triggerDoor;
    public GameObject triggerDeadEnd;
    public GameObject triggerColor;

    private PositionCheck deadEndScript;
    private bool inDeadEnd;

    [Space]

    [Header("Beat 3")]
    public GameObject triggerClocks;
    public GameObject triggerRinger;

    [Space]

    [Header("Beat 4")]
    public GameObject triggerMusic;

    void Start()
    {
        pawn = GameObject.Find("Player");
        playerScript = pawn.GetComponent<PlayerData>();
        gazeScript = wallStart.GetComponent<GazeCheck>();
        positionScript = wallStart.GetComponent<PositionCheck>();
        deadEndScript = triggerDeadEnd.GetComponent<PositionCheck>();
    }

    void Update()
    {
        BeatMachine();
        IncrementBeat();
    }

    void BeatMachine()
    {
        switch(beat)
        {
            case 0:
                Beat0();
                break;
            case 1:
                Beat1();
                break;
            case 2:
                Beat2();
                break;
        }
    }

    void IncrementBeat()
    {
        if(nextLevel)
        {
            beat++;
            nextLevel = false;
        }

    }

    

    // Intro
    void Beat0()
    {
        timeMoving = playerScript.timeMoving;

        if(timeMoving > 5)
        {
            nextLevel = true;
        }
    }

    // Line
    void Beat1()
    {
        gazeScript = wallStart.GetComponent<GazeCheck>();
        positionScript = triggerStart.GetComponent<PositionCheck>();

        RevertLayoutSwitch();

        if(!gazeScript.isVisible && positionScript.isInside){
            door.SetActive(true);
            doorCover.SetActive(false);
            nextLevel = true;
        }
    }

    // Backtrack
    void Beat2()
    {

        gazeScript = doorDeadEnd.GetComponent<GazeCheck>();
        positionScript = triggerDeadEnd.GetComponent<PositionCheck>();

        if (deadEndScript.isInside)
        {
            if (!gazeScript.isVisible && positionScript.isInside)
            {
                LayoutSwitch();
                nextLevel = true;
            }
        }
    }

    // Lost
    void Beat3()
    {
    }

    // Stairway
    void Beat4()
    {
    }

    void LayoutSwitch()
    {
        triggerColor.SetActive(true);

        GameObject[] deletedGOs;
        deletedGOs = GameObject.FindGameObjectsWithTag("LayoutSwitch");

        foreach (GameObject deletedGO in deletedGOs)
        {
            deletedGO.SetActive(false);
        }
    }

    void RevertLayoutSwitch()
    {
        triggerColor.SetActive(false);

        GameObject[] deletedGOs;
        deletedGOs = GameObject.FindGameObjectsWithTag("LayoutSwitch");

        foreach (GameObject deletedGO in deletedGOs)
        {
            deletedGO.SetActive(true);
        }
    }

}
