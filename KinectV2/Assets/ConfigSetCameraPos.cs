using UnityEngine;
using System.Collections;

public class ConfigSetCameraPos : MonoBehaviour {
	public float x,y,z;
	public Transform screenPoint;
	public Vector3 position;
	// Use this for initialization
	void Start () {
		 x = float.Parse(Parser.parser.GetSetting("HeadPositionFromCenterScreen","x"));
		 y = float.Parse(Parser.parser.GetSetting("HeadPositionFromCenterScreen","y"));
		 z = float.Parse(Parser.parser.GetSetting("HeadPositionFromCenterScreen","z"));
		position.Set (screenPoint.transform.position.x + x,screenPoint.transform.position.y + y,screenPoint.transform.position.z + z);
		transform.position = position;
		//transform.position.Set );
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
