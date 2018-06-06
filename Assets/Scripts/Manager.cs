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

    [Space]

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

    [Header("Part One")]
    public GameObject wallStart;
    public GameObject doorCover;
    public GameObject door;
    [Space]

    [Header("Part Two")]
    public GameObject doorDeadEnd;
    public GameObject triggerDeadEnd;
    public GameObject triggerColor;
    public GameObject floorStart;

    private FloorDisable floorScript;
    private PositionCheck deadEndScript;
    private bool inDeadEnd;

    void Start()
    {
        pawn = GameObject.Find("Player");
        playerScript = pawn.GetComponent<PlayerData>();
        gazeScript = wallStart.GetComponent<GazeCheck>();
        positionScript = wallStart.GetComponent<PositionCheck>();
        floorScript = floorStart.GetComponent<FloorDisable>();
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

    void Beat0()
    {
        timeMoving = playerScript.timeMoving;

        if(timeMoving > 5)
        {
            nextLevel = true;    
        }
    }

    void Beat1()
    {
        gazeScript = wallStart.GetComponent<GazeCheck>();
        positionScript = wallStart.GetComponent<PositionCheck>();

        print(gazeScript.isVisible);

        if(gazeScript.isVisible && positionScript.isInside){
            door.SetActive(true);
            doorCover.SetActive(false);
            nextLevel = true;
        }
    }


    void Beat2()
    {
        gazeScript = doorDeadEnd.GetComponent<GazeCheck>();
        positionScript = doorDeadEnd.GetComponent<PositionCheck>();

        if (deadEndScript.isInside)
        {
            if (gazeScript.isVisible && positionScript.isInside)
            {
                floorScript.enabled = true;
                triggerColor.SetActive(true);

                GameObject[] deletedGOs;
                deletedGOs = GameObject.FindGameObjectsWithTag("LayoutSwitch");

                foreach (GameObject deletedGO in deletedGOs)
                {
                    deletedGO.SetActive(false);
                }
            }
        }
    }
}
