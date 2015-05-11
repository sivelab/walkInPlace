using UnityEngine;
using System.Collections;

public class ResetTreadCube : MonoBehaviour {

	public string buttonName;
	public float speed;
	public float time; 

	public string startMovement;
	public bool move = false;
	private Vector3 initialPosition;

	// Use this for initialization
		void Start () {
	//	Transform transform = GetComponent<Transform>();
		initialPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (move)
		{
			Vector3 curPos = transform.position;
			//curPos = curPos +transform.forward * speed * Time.deltaTime;
			curPos = curPos +transform.forward * Navigation.curVelocity * Time.deltaTime;
			transform.position = curPos;
		}
		if (Vi.vrpnButton(buttonName + "Start@131.212.41.96", 0))
		{
			Debug.Log("WOOPETY");
			move = true;
		}
		if (Vi.vrpnButton(buttonName + "Reset@131.212.41.96", 0))
		{
			Debug.Log("WOOPETYReset");
			move = false;
		}
		if (Input.GetKeyDown(startMovement))
		{
			move = true;
		}

		if (Input.GetKeyDown("p"))
		{
			transform.position = initialPosition;
			rigidbody.velocity = Vector3.zero;
			move = false;
		}
		/*
		if(transform.position.x < -4.5f)
			{
				Vector3 initialPos = Vector3.zero;
				initialPos.Set (3.0f,curPos.y,curPos.z);
				transform.position = initialPos;
			}
			*/
	}
}
