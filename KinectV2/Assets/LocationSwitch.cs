using UnityEngine;
using System.Collections;

public class LocationSwitch : MonoBehaviour {
	private Vector3 StartPos;
	private Quaternion StartRot;
	public Transform []locations= new Transform[5];
	public int curLocation = 0;
	public string AxisForReset = "ChangePosition";
	// Use this for initialization
	void Start () {
		StartPos = transform.position;
		StartRot = transform.rotation;
		changePosition();
//		Debug.Log (locations.Length);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("c"))
		{
			curLocation++;
			curLocation%= locations.Length + 1;
			changePosition();

		}
		if(Input.GetAxis (AxisForReset) > 0)
		{
			changePosition();
		}

	}
	public void changePosition()
	{
		if (curLocation == 0) //initial Position
		{
			transform.rotation = StartRot;
			transform.position = StartPos;
		}
		else
		{
			transform.position = locations[curLocation-1].position;
			transform.rotation = locations[curLocation-1].rotation;
		}


		/*
		switch(curLocation)
		{
		case 0:
			//Debug.Log ("TESTING");
			transform.rotation = StartRot;
			transform.position = StartPos;
			if (rigidbody != null)
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}			
			//Debug.Log ("TEST0");
			break;
		case 1:
			transform.position = location2.position;
			transform.rotation = location2.rotation;
			//Debug.Log ("TEST1");
			break;
		case 2:
			transform.position = location3.position;
			transform.rotation = location3.rotation;
			//Debug.Log ("TEST2");
			break;
		case 3:
			transform.position = location4.position;
			transform.rotation = location4.rotation;
			//Debug.Log ("TEST3");
			break;

		}//end switch
		*/
	}
}
