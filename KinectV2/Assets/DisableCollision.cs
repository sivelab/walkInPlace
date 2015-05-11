using UnityEngine;
using System.Collections;

public class DisableCollision : MonoBehaviour {
	public CharacterController c;
	// Use this for initialization
	void Start () {
		c = GetComponent<CharacterController>();
		c.detectCollisions = false;
	}
	
	// Update is called once per frame
	void Update () {
			c.detectCollisions = false;
	}
}
