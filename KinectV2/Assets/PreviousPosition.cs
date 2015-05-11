using UnityEngine;
using System.Collections;

public class PreviousPosition : MonoBehaviour {
	public  Vector3 lastpos;
	private int size;
	private int curpos;
	private Vector3[] positions;

	// Use this for initialization
	void Start () {
		size = 2;
		positions = new Vector3[size];
		curpos = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (curpos == -1)
		{
			curpos++;
			positions[curpos] = transform.position;
		}
		else
		{
			lastpos = positions[curpos];
			curpos += 1;
			curpos %= size;
			positions[curpos] = transform.position;

		}
	}

}
