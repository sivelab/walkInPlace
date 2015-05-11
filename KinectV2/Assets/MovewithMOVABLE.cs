using UnityEngine;
using System.Collections;

public class MovewithMOVABLE : MonoBehaviour {
	public float xdistance;
	public float ydistance;
	public float zdistance;
	public Transform objecttoshadow;
	
	public Vector3 translation;
	// Use this for initialization
	void Start () {
		//Vector3 test  =  new Vector3( objecttoshadow.position.x + xdistance, objecttoshadow.position.y + ydistance, objecttoshadow.position.z + zdistance);
		translation.Set( objecttoshadow.position.x + xdistance, objecttoshadow.position.y + ydistance, objecttoshadow.position.z + zdistance);
		transform.position = translation;
	}	
	
	// Update is called once per frame
	void Update () {
			//	Vector3 test  =  new Vector3( objecttoshadow.position.x + xdistance, objecttoshadow.position.y + ydistance, objecttoshadow.position.z + zdistance);
		translation.Set( objecttoshadow.position.x + xdistance, objecttoshadow.position.y + ydistance, objecttoshadow.position.z + zdistance);
		transform.position = translation;
		transform.rotation = objecttoshadow.rotation;
		
		
		//Vector3 translation = new Vector3(6,0,0);
		//translation.Set( objecttoshadow.position.x + xdistance, objecttoshadow.position.y + ydistance, objecttoshadow.position.z + zdistance);
		//transform.position = translation;	
	}
}
