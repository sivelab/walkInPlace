using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	public string nextLevel = "default";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("h"))
		{
			Application.LoadLevel(nextLevel);
		}
	}
}
