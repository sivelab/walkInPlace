using UnityEngine;
using System.Collections;

public class SteppingStoneCreation : MonoBehaviour {

	public Transform steppingStoneModel;
	public int numberOfStones=10;
	public float stepOffsetX=0.5f;
	public float stepOffsetZ=1.0f;
	public Navigation navigation;
	public Transform leftFoot;
	public Transform rightFoot;
	public Transform waterLevel;
	public Transform FPCMoving;
	private GameObject steppingStoneParent;
	private LocationSwitch lSwitch;
	private bool reset = false;
	private float resetTime = 0;
	public Transform leftHand;
	public Transform rightHand;
	// Use this for initialization
	void Start () {
		steppingStoneParent =  new GameObject("steppingStoneParent");
		lSwitch = FPCMoving.GetComponent<LocationSwitch>();
		//create a bunch of gameobjects of the stepping stone model placing them littered throughout the pond
		for (int i =0; i < numberOfStones; i++)
		{
			//GameObject o = new GameObject("stepStone"+i);
			Transform o = (Transform)Instantiate(steppingStoneModel);
			o.parent= steppingStoneParent.transform;
			if (i % 2 == 0)//even
			{
				Vector3 newPosition = o.position;
				newPosition.z += stepOffsetZ*(i+1);
				newPosition.x -= stepOffsetX;
				o.position = newPosition;
			}
			else // odd
			{
				Vector3 newPosition = o.position;
				newPosition.z += stepOffsetZ*(i+1);
				o.position = newPosition;
			}
		}
	}	
	
	// Update is called once per frame
	void Update () {
		//when set
		if(rightFoot.position.y < waterLevel.position.y -.6f || leftFoot.position.y < waterLevel.position.y -.6f)
		{
			//turn off walking in place
			navigation.setWalkInPlace(false);
			//reset player position
			lSwitch.changePosition();
			reset = true;
			resetTime = Time.time;
		}
		if (reset && Time.time - resetTime > 2.0f)
		{
			navigation.setWalkInPlace(true);
		}
		Vector3 handDistance = leftHand.position - rightHand.position;
		if (handDistance.magnitude < 0.15f)
		{
			//turn off walking in place
			navigation.setWalkInPlace(false);
			//reset player position
			lSwitch.changePosition();
			reset = true;
			resetTime = Time.time;
		}
	}
}
