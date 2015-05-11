using UnityEngine;
using System.Collections;

public class GUIGeneral : MonoBehaviour {
	public int width;
	public float box1;
	public float box2;
	public Texture btnTexture;
	bool menuOpen = false;
	float menuOpenTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(Input.GetAxis("Menu") > 0)
		{
//			Debug.Log(menuOpen );
			if (menuOpen && Time.time - menuOpenTime > 1)
			{
				menuOpenTime = Time.time;
				menuOpen = false;
			}
			else if (!menuOpen && Time.time - menuOpenTime > 1)
			{
				menuOpenTime = Time.time;
				menuOpen = true;
			}
		}
		if (menuOpen)
		{
			if (!btnTexture) {
				Debug.LogError("Please assign a texture on the inspector");
				return;
			}

			 width = Screen.width;
			int height = Screen.height;


			//  x = width = 2560
			// y = .5 x = 1280
			// w = .5 y = 640
			// 2560 / 32 = 80
			// (24 * width)/32 - (width / 32) 
			//(23 * width)/32
			// ( 31 * width) / 32
			// box1 = -1*23/32 * width;
			 // box2 = -1*31/32 * width;
			box1 = -1 * 20 * width  / 32;
			box2 = -1 * 28 * width  / 32;
			GUIUtility.RotateAroundPivot(90, new Vector2(160, 30));
			loadMenu (box1);
			loadMenu (box2);
			//GUI.Box(new Rect(140,box1,180,50), btnTexture);
			//GUI.Box(new Rect(140,box2,180,50), btnTexture);
			/*
			GUIUtility.RotateAroundPivot(90, new Vector2(160, 30));
			GUI.Box(new Rect(140,box1,180,50), btnTexture);
			GUI.Label(new Rect(150, box1, 300, 50), "Time : " + Time.timeSinceLevelLoad);
			GUI.Box(new Rect(140,box2,180,50), btnTexture);
			GUI.Label(new Rect(150, box2, 300, 50), "Time : " + Time.timeSinceLevelLoad);
			*/
			/*
			//GUIUtility.RotateAroundPivot(0,new Vector2(Screen.width / 2, Screen.height / 2));
			if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
			{
				Debug.Log("Clicked the button with an image");
			}




			if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
			{
				Debug.Log("Clicked the button with text");	
			}
			*/
		}
	}

	void loadMenu(float box)
	{
		GUI.Box(new Rect(140,box,360,200), btnTexture);
		GUI.Label(new Rect(150, box, 300, 50), "Time : " + Time.timeSinceLevelLoad);
		if (GUI.Button(new Rect(150, box+50, 50, 30), "Mars"))
		{
			Application.LoadLevel("Mars");
			Debug.Log("Loading Mars");
		}
		if (GUI.Button(new Rect(150, box+100, 150, 30), "Bisection Test"))
		{
			Application.LoadLevel("Bisection Test");
			Debug.Log("Loading Bisection Test");
		}
	}

}
