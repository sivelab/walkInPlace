
using UnityEngine;
using System.Collections;
using UnityEditor;

public class GesturalInput : MonoBehaviour {

	public Transform locationSwitchLocation;
	public Transform navigationLocation;
	public Transform leftHand;
	public Transform rightHand;
	public Transform virtualFloor;

	private Navigation navigation;
	private LocationSwitch lSwitch;
	private float resetTime=0;
	private bool reset = false;
	private float holdTime=0;
	private bool started = false;
	public bool touchHandStart = true;
	public bool rightHandUpPause = true;
	public bool heightChangeStopDebug = false;

	// Use this for initialization
	void Start () {
		navigation = navigationLocation.GetComponent<Navigation>();
		lSwitch = locationSwitchLocation.GetComponent<LocationSwitch>();
	}
	
	// Update is called once per frame
	private float virtualFloorInitialY;
	private bool initial = true;
	private float startTime;
	void Update () {



		//Reset walking position
		if( touchHandStart)
		{
			//debugging method to pause when virtual floor is raised
			if (heightChangeStopDebug && started )
			{
				if (initial)
				{
					initial = false;
					startTime= Time.time;
				}
				if (Time.time - startTime > 2)
				{
					virtualFloorInitialY = virtualFloor.position.y;
					startTime = 9999999;
				}
				if (virtualFloorInitialY < virtualFloor.position.y - .08f  && startTime > 10000)
				{
					EditorApplication.isPaused = true;
				}
			}

			touchHandStartMethod();
		}
		// Pause Editor
		if (rightHandUpPause)
		{
			if (rightHand.position.y - leftHand.position.y > 1)
				EditorApplication.isPaused = true;
		}

	}

	private void touchHandStartMethod()
	{
		if (reset)// && (Time.time - resetTime) > 0.1f)
		{
			navigation.setWalkInPlace(true);
			started = true;
			reset = false;
		}
		Vector3 handDistance = leftHand.position - rightHand.position;
		if (handDistance.magnitude < 0.15f)
		{
			if(holdTime==0)
			{
				holdTime = Time.time;
			}
			else if (Time.time - holdTime > 1.0f)
			{
				//EditorApplication.isPaused = true;
				//turn off walking in place
				navigation.setWalkInPlace(false);
				//reset player position
				lSwitch.changePosition();
				reset = true;
				resetTime = Time.time;
			}
		}
		else
		{
			holdTime = 0;
		}
	}


}


