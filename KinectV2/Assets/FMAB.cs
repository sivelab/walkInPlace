using UnityEngine;
using System.Collections;

public class FMAB : MonoBehaviour {

	private float timetouched = 0;
	//private string test1 = "test1";
	//private string test2 = "test2";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision col)
	{
		//transform.localScale += new Vector3(1,1,1);
		//Debug.Log(test1);
		//Debug.Log (col.collider.name);
		if(col.collider.name == "HandSphereLeft" )
		{
			Debug.Log (col.collider.name);
		}



	}
	void OnCollisionEnter(Collision col)
	{
		//transform.localScale += new Vector3(1,1,1);
		//Debug.Log(test2);
		if(col.collider.name == "HandSphereLeft" )
		{
			timetouched += Time.deltaTime;
			//Debug.Log (col.collider.name);
		}
		
		
		
	}
}
