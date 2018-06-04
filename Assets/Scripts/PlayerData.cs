using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	private bool isMoving;
	private bool isLooking;
	private bool headedNorth;
	public Transform playerTransform;

    public float timeMoving;
    public float timeStill;

    private float currentLocation;
    private float lastLocation;

	void Start ()
	{
        playerTransform = gameObject.GetComponent<Transform>();
	}
	

	void Update ()
	{
		Moving();
		Timer();
		Direction();
	}

	void Moving()
	{
		if((Mathf.Abs(Input.GetAxis("Horizontal")) > 0) || (Mathf.Abs(Input.GetAxis("Vertical")) > 0))
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}
	}

	void Timer()
	{

		if(isMoving)
		{
			timeMoving = timeMoving + Time.deltaTime;
		}
		else
		{
			timeStill = timeStill + Time.deltaTime;
		}
	}

	void Direction()
	{
		if(isMoving)
		{
			currentLocation = playerTransform.position.z;

			if(currentLocation > lastLocation)
			{
				headedNorth = true;
				lastLocation = lastLocation + currentLocation;
			}
            else
			{
				headedNorth = false;
				lastLocation = currentLocation + 0.1f;
			}
		}
	}
}
