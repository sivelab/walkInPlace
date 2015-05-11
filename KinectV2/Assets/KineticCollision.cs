using UnityEngine;
using System.Collections;

public class KineticCollision : MonoBehaviour {
	
	public AudioClip smack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("OnTriggerEnter");
		GameObject hit;
		hit = GameObject.Find (col.gameObject.name);
		ResetTreadCube rtc = hit.GetComponent<ResetTreadCube>();
		rtc.move = false;
		AudioSource.PlayClipAtPoint(smack, transform.position);
	}
	void OnTriggerStay(Collider other) {
		Debug.Log("TRIGGERSTAY");
		if (other.attachedRigidbody)
		{
			other.attachedRigidbody.AddForce(Vector3.back * 3);
			other.attachedRigidbody.AddForce(Vector3.up * 3);
		}
		
	}
	void OnCollisionEnter(Collision col)
	{
		Debug.Log("COLLISIONENTER");

	}
}
