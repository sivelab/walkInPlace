using UnityEngine;
using System.Collections;

public class Parser : MonoBehaviour {
	public static IniParser parser;
	// Use this for initialization
	void Start () {
	parser = (IniParser)ScriptableObject.CreateInstance("IniParser") as IniParser;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
