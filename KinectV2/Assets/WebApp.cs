using UnityEngine;
using System.Collections;

public class WebApp : MonoBehaviour {
	public bool button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		button = Vi.vrpnButton("Button0@131.212.41.96",0);
		Debug.Log(button);
	}
}
