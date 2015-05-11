using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public string verticalAxes;
	public string horizontalAxes;
	public CharacterController test;
	//public string mousex;
	//public string mousey;
	bool usable;
	//bool mouse;
	//public float yaw;
	//public float pitch;
	public Vector3 directionVector;
	// Use this for initialization
	void Start () {
		usable = true;
		directionVector = Vector3.zero;
		if(string.IsNullOrEmpty(verticalAxes))
		{
			usable = false;
		}
		if(string.IsNullOrEmpty(horizontalAxes))
		{
			usable = false;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.eulerAngles = new Vector3(pitch, yaw, 0f);
		if (usable)
		{
			//get strafe left/right and forward/back
			directionVector.Set(Input.GetAxis(horizontalAxes), 0, Input.GetAxis(verticalAxes)); 
			//move forward/back
			transform.Translate( transform.forward *directionVector.z * Time.deltaTime, Space.World); 
			//move left/right
			transform.Translate( transform.right *directionVector.x * Time.deltaTime, Space.World); 
		}

	}
}
