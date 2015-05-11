using UnityEngine;
using System.Collections;

public class Kicktheball : MonoBehaviour {
	private float lastKick = -1;
	private Vector3 dir;
	private PreviousPosition PP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if((col.collider.name == "FootSphereLeft" || col.collider.name == "FootSphereRight") &&
		   (Time.time - lastKick > 1))
		{
			lastKick = Time.time;
			//transform.localScale += new Vector3(1,1,1);


			dir = transform.position - (col.transform.position + Vector3.up + Vector3.back);
			dir.y = .5f;
			dir.Normalize();
			PP = GameObject.Find (col.collider.name).GetComponent<PreviousPosition>();
			float force = (col.transform.position - PP.lastpos).magnitude / Time.deltaTime;
			Debug.Log(force);
			Debug.Log (dir);
			//Debug.Log(col.relativeVelocity.magnitude);
			rigidbody.AddForce(dir * force, ForceMode.Impulse);
			//rigidbody.AddForce(new Vector3(0,0,1) * 10, ForceMode.Impulse);
			//Debug.Log(col.collider.transform.position);
		}
		//Debug.Log (col.collider.name);
	}
}
