using UnityEngine;
using System.Collections;

public class ChecKDisplayFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(HUDFPS.displaynumber == 1)
			camera.depth = 13;
		else
			camera.depth = 10;
	}
}
