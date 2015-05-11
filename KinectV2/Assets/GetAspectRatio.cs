using UnityEngine;
using System.Collections;

public class GetAspectRatio : MonoBehaviour {
	public float ar;
	// Use this for initialization
	void Start () {
	//camera.aspect = camera.aspect / aspect;
	//camera.aspect = camera.aspect /2.5f;
	ar = camera.aspect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
