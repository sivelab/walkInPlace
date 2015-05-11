using UnityEngine;
using System.Collections;

public class ResetOnButtonPress : MonoBehaviour {
	private Vector3 InitialPos;
	private Quaternion InitialRot;
	public string AxisForReset = "ResetBallPosition";
	// Use this for initialization
	void Start () {
		InitialPos = transform.position;
		InitialRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis (AxisForReset) > 0)
		{
			transform.rotation = InitialRot;
			transform.position = InitialPos;
			if (rigidbody != null)
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
			//rigidbody.
			//rigidbody.freezeRotation
		}
	}
}
