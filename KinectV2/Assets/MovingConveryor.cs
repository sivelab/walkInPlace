using UnityEngine;
using System.Collections;

public class MovingConveryor : MonoBehaviour {
	public float treadmillSpeed;
	private float offset=0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("MC" + Navigation.curVelocity);
		offset += (-1 * Navigation.curVelocity * Time.deltaTime);
		//float offset = -1*treadmillSpeed*Time.time;
		
	renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
		
	}
}
