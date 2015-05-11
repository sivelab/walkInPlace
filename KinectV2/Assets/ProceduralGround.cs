using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProceduralGround : MonoBehaviour {

	public Transform followObject;//the object to create the procedural ground around
	public int numberOfObjects = 40;
	public float threshold = 80;
	public float scale = 1.0f;
	public Transform [] objects = new Transform[5];


	private float initialSeed;//for semirandomization (makes the same random each time)
	private Queue<Transform> objectQueue;
	private Vector3 nextPosition;
	private Vector3 startPosition;
	private Vector3 setPosition;

	private float distanceMoved;



	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		initialSeed = transform.position.magnitude;//the same random seed each time
		Random.seed = (int)Mathf.Floor(initialSeed);
		int index = 0; 
		startPosition = followObject.position;
		startPosition.y = 0.5f + .08f;
		nextPosition = startPosition;
		setPosition = startPosition;
		for (int i = 0; i < numberOfObjects; i++) {
			index = (int)Mathf.Floor(Random.value * (objects.Length - 1)); // 0, 1, 2, 3, or 4 if length = 5
			Transform o = (Transform)Instantiate(objects[index]);

			//Gives the ball a variable size based on a normal distrubution with center .5 and mean .1, capped at 0 and 1
			o.localScale = o.localScale * NextGaussianFloat() * scale;

			Vector3 dir = startPosition;
			dir.x += (Random.value - 0.5f);
			dir.z += (Random.value - 0.5f);
			dir = dir - startPosition;
			dir.Normalize();
			nextPosition = startPosition + dir * ((Random.value + 6/threshold )* (threshold));//randomnly 2 - 82 units away
			//y position is height of terrain + offset to stick it out of the ground a little
			Vector3 rockheight = nextPosition;
			rockheight.y += 10000;
			RaycastHit hit;
			if(Physics.Raycast(rockheight, -1*Vector3.up, out hit))
			{
				rockheight.y = hit.point.y;
				Debug.Log (rockheight);
			}
			nextPosition.y = rockheight.y + .3f;
			//nextPosition.y = Terrain.activeTerrain.SampleHeight(nextPosition) + (o.localScale.x/2);
			o.localPosition = nextPosition;
			objectQueue.Enqueue(o);
		}

	}


	// Update is called once per frame
	void Update () {

		
		// when 10 meters is moved away from last position, recalculate the position of all objects.  
		Vector3 lengthVector = followObject.position - setPosition;
		lengthVector.y = 0;// don't care about height
		distanceMoved = lengthVector.magnitude;
		if (distanceMoved > 10)
		{	
			distanceMoved = 0;
			setPosition = followObject.position;
			foreach (Transform obj in objectQueue)
			{
				Vector3 tVector = obj.position - followObject.position;
				tVector.y = 0;
				if ( tVector.magnitude > threshold + 6)
				{
					//tVector.y += 20;
					//moves the object 65-75 meters away in a random direction
					tVector.x = (Random.value - 0.5f); // (-0.5 to 0.5)
					tVector.z = (Random.value - 0.5f); // (-0.5 to 0.5)
					Vector3 forward = followObject.forward;
					forward.Normalize ();

					tVector += forward / 4;//skew the random displace to the forward direction
					tVector.y = 0;
					tVector.Normalize();
					tVector = tVector * ((threshold - 8) + 10 * (Random.value - .5f));

					tVector = tVector + followObject.position;
					Vector3 rockheight = tVector;
					rockheight.y += 10000;
					RaycastHit hit;
					if(Physics.Raycast(rockheight, -1*Vector3.up, out hit))
					{
						rockheight.y = hit.transform.position.y;
					}
					tVector.y = rockheight.y;
					//tVector.y = Terrain.activeTerrain.SampleHeight(tVector)+ (obj.localScale.x/2);
					obj.position = tVector;
				}
			}
		}

	}




	//Returns a random number in a guassian distrubtion.  The mean is deviation is 0.1 centered around 0.5
	//If a number is below 0, it is set to 0.01, if a number is above 1 it is set to one.

	//Uses the Box Mueller Polar Form method
	public static float NextGaussianFloat()
	{
		float u, v, S;
		
		do
		{
			u = 2.0f * Random.value - 1.0f;
			v = 2.0f * Random.value - 1.0f;
			S = u * u + v * v;
		}
		while (S >= 1.0f);

		float fac = Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
		fac = u * fac;
		fac = fac*0.1f + 0.5f;
		if (fac < 0.0f){
			fac = 0.01f;
		}
		else if (fac > 1.0f){
			fac = 1.0f;
		}
		return fac;
	}
}



/*	Old infinite hallway Code
 * 		for (int i = 0; i < numberOfHallways; i++) {
			Transform o = (Transform)Instantiate (hallway);
			nextHallwayPosition.z += 30;
			o.position = nextHallwayPosition;
			hallwayQueue.Enqueue(o);
		
		
		}
 * 
 * 
 * 		if (hallwayQueue.Peek().position.z < followObject.position.z - 30) {
			Transform o = hallwayQueue.Dequeue();
			nextHallwayPosition.z += 30;
			o.position = nextHallwayPosition; 
			hallwayQueue.Enqueue(o);
		}
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */
