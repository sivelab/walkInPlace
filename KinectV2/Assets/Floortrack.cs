using UnityEngine;
using System.Collections;

//Tracks the head position to the screen.  It's a simple test so it only works in the start orientation.

public class Floortrack : MonoBehaviour {
	public Transform referencePoint;
	public Transform floorScreen;
	public Transform frontScreen;
	public int sphereType; //floor = 1, front = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = referencePoint.position;
		if (sphereType == 1)//floor
		{
			temp.y = floorScreen.position.y;
		}
		else if (sphereType == 2)//floor
		{
			temp.z = frontScreen.position.z;
		}
		transform.position = temp;
		//temp.z =
	}
}
