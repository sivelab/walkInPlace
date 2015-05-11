using UnityEngine;
using System.Collections;

public class Nudge : MonoBehaviour {
	private Vector3 small;
	// Use this for initialization
	void Start () {
		small = new Vector3 (0,0,0);//transform.position.y +.00000000000000001f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + small;
	}
}
