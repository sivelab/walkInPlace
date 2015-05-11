using UnityEngine;
using System.Collections;

public class VRPN : MonoBehaviour {
	public string address;
	public Vector3 trackPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//bool btrue = Vi.vrpnButton(address, 0);
		trackPos = Vi.vrpnTrackerPos(address);
		transform.position = trackPos;
		//rigidbody.useGravity = Vi.vrpnButton("Button0@localhost",0);
	}
}
