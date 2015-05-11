using UnityEngine;
using System.Collections;

public class CopyPosition : MonoBehaviour {
	public Transform head;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = head.position;
	}
}
