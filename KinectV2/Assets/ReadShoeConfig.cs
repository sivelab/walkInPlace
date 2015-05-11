using UnityEngine;
using System.Collections;

public class ReadShoeConfig : MonoBehaviour {
	
	public static string IPleftshoe;
	public static string IPrightshoe;
	public static int port;
	public static int[] chambers;

	
	// Use this for initialization
	void Start () {
		IniParser parser = (IniParser)ScriptableObject.CreateInstance("IniParser") as IniParser;
		parser.init ("shoeconfig.txt");
		IPleftshoe = (parser.GetSetting("shoe","ipaddressleft"));
		IPrightshoe = (parser.GetSetting("shoe","ipaddressright"));
		port = int.Parse(parser.GetSetting("shoe","port"));
		chambers = new int[12];
		chambers[0]  = int.Parse(parser.GetSetting("chamberheights","chamber1"));
		chambers[1]  = int.Parse(parser.GetSetting("chamberheights","chamber2"));
		chambers[2]  = int.Parse(parser.GetSetting("chamberheights","chamber3"));
		chambers[3]  = int.Parse(parser.GetSetting("chamberheights","chamber4"));
		chambers[4]  = int.Parse(parser.GetSetting("chamberheights","chamber5"));
		chambers[5]  = int.Parse(parser.GetSetting("chamberheights","chamber6"));
		chambers[6]  = int.Parse(parser.GetSetting("chamberheights","chamber7"));
		chambers[7]  = int.Parse(parser.GetSetting("chamberheights","chamber8"));
		chambers[8]  = int.Parse(parser.GetSetting("chamberheights","chamber9"));
		chambers[9] = int.Parse(parser.GetSetting("chamberheights","chamber10"));
		chambers[10] = int.Parse(parser.GetSetting("chamberheights","chamber11"));
		chambers[11] = int.Parse(parser.GetSetting("chamberheights","chamber12"));
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
