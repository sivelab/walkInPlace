using UnityEngine;
using System.Collections;

public class TestCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	//rightFootVirtualCC.collisionFlags & CollisionFlags.Sides)!=0
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("COLLIDED");
	}
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("TRIIGGERERED");
	}
}
