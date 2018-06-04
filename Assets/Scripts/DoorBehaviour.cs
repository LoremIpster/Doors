using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour {

    public Animator animator;

    public GameObject door;
    public GameObject triggerInside;
    public GameObject triggerOutside;

    private bool playerVisible;
    private bool playerInside;
    private bool playerOutside;

    void Update()
    {

        GazeCheck doorScript = door.GetComponent<GazeCheck>();
        playerVisible = doorScript.isVisible;

        PositionCheck insideScript = triggerInside.GetComponent<PositionCheck>();
        playerInside = insideScript.isInside;

        TriggerOutside outsideScript = triggerOutside.GetComponent<TriggerOutside>();
        playerOutside = outsideScript.isOutside;

        if (playerVisible && playerInside)
        {
            animator.SetBool("isOpen", true);
        }
        else if (playerOutside)
        {
            animator = door.GetComponent<Animator>();
            animator.SetBool("isOpen", false);
        }
	}
}

