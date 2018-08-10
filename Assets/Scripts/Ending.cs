using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    private GazeCheck gazeScript;
    private PositionCheck positionScript;
    private PositionCheck restartScript;
    private bool textDisplayed;
    private bool staircaseReady;

    public GameObject triggerEnding;
    public GameObject triggerRestart;
    public GameObject gazeObject;
    public GameObject textEnding;
    public GameObject collisionFront;
    public GameObject collisionBack;
    public GameObject finalStaircaseFirstHalf;
    public GameObject finalStaircaseSecondHalf;

    void Start()
    {
        gazeScript = gazeObject.GetComponent<GazeCheck>();
        positionScript = triggerEnding.GetComponent<PositionCheck>();
        restartScript = triggerRestart.GetComponent<PositionCheck>();

        textDisplayed = false;
        staircaseReady = false;
    }

    void Update()
    {
        StaircaseSwitch();
        Reset();
    }

    private void StaircaseSwitch()
    {
        if (!gazeScript.isVisible && positionScript.isInside && !textDisplayed)
        {
            textEnding.SetActive(true);
            finalStaircaseFirstHalf.SetActive(false);
            staircaseReady = true;
            textDisplayed = true;
        }

        if (gazeScript.isVisible && positionScript.isInside && staircaseReady)
        {
            finalStaircaseSecondHalf.SetActive(true);
            collisionFront.SetActive(false);
        }

        if (!gazeScript.isVisible && positionScript.isInside && textDisplayed)
        {
            textEnding.SetActive(true);
            collisionBack.SetActive(true);
        }
    }

    private void Reset()
    {
        if (restartScript.isInside)
        {
            textDisplayed = false;
            staircaseReady = false;
            finalStaircaseFirstHalf.SetActive(true);
            finalStaircaseSecondHalf.SetActive(false);
            collisionBack.SetActive(false);
            collisionFront.SetActive(true);
        }
    }

}
