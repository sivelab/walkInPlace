using UnityEngine;
using System.Collections;

public class CheckDisplay : MonoBehaviour {
	public float test =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (HUDFPS.displaynumber <1)
			camera.depth = 30;
		else 
			camera.depth = 5;
		
		test = HUDFPS.displaynumber;
	}
}
