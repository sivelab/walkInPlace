using UnityEngine;
using System.Collections;

public class StayRelativeMirror : MonoBehaviour {

	public Transform cam1;//FPC TPAWT MOVABLE
	public Transform rel1;//TPAWTMOCKERY
	public Transform cam2;//FPC TPAWT
	public Transform rel2;//TPAWT


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.eulerAngles.y = test;
		//transform.position = (rel1.position - cam1.position) + cam2.position
		
		
		//takes the vector from rel1 to cam1 and adds it to the position of rel2
		//this makes the position of cam2 the same relative to the position of cam1 from rel1
		cam2.position = ((cam1.position - rel1.position) + rel2.position);
		
		//rotate cam2 around the rotation of rel2, so that if rel2 was not aligned the same
		//as rel1, cam2 is still in the right spot

		Transform temp1 = cam2; Transform temp2 = cam2;
		temp1.RotateAround(rel2.position,Vector3.up,rel2.transform.eulerAngles.x);//correct y
		temp2.RotateAround(rel2.position,Vector3.up,rel2.transform.eulerAngles.z);//correct leftright

		//cam2 = temp1;

		Vector3 temp3 = temp2.position;
		temp3.y = temp1.position.y;

		temp2.position = temp3;

		cam2 = temp2;

		//cam2.RotateAround(rel2.position,Vector3.up,rel2.transform.eulerAngles.x);
		//cam2.RotateAround(rel2.position,Vector3.up,rel2.transform.eulerAngles.z);

		//cam2.eulerAngles = rel2.eulerAngles; 
	}
}
