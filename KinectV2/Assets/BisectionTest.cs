using UnityEngine;
using System.Collections;
using System.IO;

public class BisectionTest : MonoBehaviour {

	public Transform testObject;
	public Transform headTransform;
	public Transform midBall;
	private Vector3 startPosition;
	StreamWriter writer;
	// Use this for initialization
	void Start () {

		startPosition =  new Vector3(headTransform.position.x,headTransform.position.y,headTransform.position.z);
		writer = new StreamWriter("e:\\TestOutput\\test.txt");
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("b"))
		{
			startPosition = headTransform.position;

			writer.WriteLine("New Start Position Set at " + startPosition);
		}
		if(Input.GetKeyDown("m"))
		{
			DetermineMiddle();
		}
		if(Input.GetKeyDown("n"))
		{
			RandomizeStart();
		}
		if(Input.GetKeyDown("v"))
		{
			
			writer.Close();
		}


	}


	void RandomizeStart() {
		Vector3 forward = (headTransform.position - testObject.position);
		forward.Normalize();
		forward = testObject.position + forward*((Random.value - 0.5f)*4);
		forward.y = Terrain.activeTerrain.SampleHeight(forward) + testObject.localScale.z / 2f;
		testObject.position = forward;
	}
	void DetermineMiddle() {
		Vector3 v1 = testObject.position - startPosition;
		v1 = v1 / 2;
		Vector3 middlePoint = startPosition + v1;
		Vector3 diff = middlePoint - headTransform.position;
		writer.WriteLine("\tEnd Position was " + testObject.position);
		writer.WriteLine("\tMiddle Position supposed to be " + middlePoint);
		writer.WriteLine("\tPerson Stopped at " + headTransform.position);
		writer.WriteLine("\tDifference of " + diff + "or ");

		diff.y = 0;
		if(Vector3.Dot(v1,diff) < 0) //stopped too late
		{
			writer.WriteLine ("\t\tStopped " + diff.magnitude + " meters in front"); 
		}
		else // stopped early
		{
			writer.WriteLine ("\t\tStopped " + diff.magnitude + " meters behind"); 
		}
		/*
		Transform o = (Transform)Instantiate(midBall);
		middlePoint.y = testObject.position.y;
		o.position = middlePoint;
		*/
	}


}
