using UnityEngine;
using System.Collections;

public class IniParserTest : MonoBehaviour {
	
	public static float screenHeight;
	public static float screenWidth;
	
	
	// Use this for initialization
	void Start () {
        //IniParser parser = new IniParser("config.txt");
 		IniParser parser = (IniParser)ScriptableObject.CreateInstance("IniParser") as IniParser;
		parser.init ("config.txt");
		screenHeight = float.Parse (parser.GetSetting("screen","height"));
		screenWidth  = float.Parse (parser.GetSetting("screen","width"));
		print (screenHeight);
		print (screenWidth);	

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
