using UnityEngine;
using System.Collections;

public class SetScreenCam : MonoBehaviour {
	
	public float screenHeight;
	public float screenWidth;
	// Use this for initialization
	void Start () {
 		//Parser.parser = (IniParser)ScriptableObject.CreateInstance("IniParser") as IniParser;
		
		screenHeight = float.Parse (Parser.parser.GetSetting("screen","height"));
		screenWidth  = float.Parse (Parser.parser.GetSetting("screen","width"));
		//print (screenHeight);
		//print (screenWidth);
		ModifyScreenCam.width = screenWidth;
		ModifyScreenCam.height = screenHeight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
