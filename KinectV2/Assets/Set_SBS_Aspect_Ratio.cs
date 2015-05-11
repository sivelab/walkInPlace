using UnityEngine;
using System.Collections;

public class Set_SBS_Aspect_Ratio : MonoBehaviour {
	public float ar;
	// Use this for initialization
	void Start () {


	ar = camera.aspect * 2; // doubles the height of the screen (essentially halving the width)
	camera.aspect = ar;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
