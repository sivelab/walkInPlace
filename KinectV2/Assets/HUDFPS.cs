﻿using UnityEngine;
using System.Collections;
 
public class HUDFPS : MonoBehaviour 
{
 
// Attach this to a GUIText to make a frames/second indicator.
//
// It calculates frames/second over each updateInterval,
// so the display does not keep changing wildly.
//
// It is also fairly accurate at very low FPS counts (<10).
// We do this not by simply counting frames per interval, but
// by accumulating FPS for each frame. This way we end up with
// correct overall FPS even if the interval renders something like
// 5.5 frames.
 
public  float updateInterval = 0.5F;
public  static int displaynumber = 0; 
	
	
private float accum   = 0; // FPS accumulated over the interval
private int   frames  = 0; // Frames drawn over the interval
private float timeleft; // Left time for current interval
private float wait; 
	
void showfps()
	{
		//Frames Per Second (FPS)
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("OBSERVER CAM \n{0:F2} FPS",fps);
			guiText.text = format;
			
			if(fps < 30)
				guiText.material.color = Color.yellow;
			else 
			if(fps < 10)
				guiText.material.color = Color.red;
			else
				guiText.material.color = Color.green;
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}//end FPS		
	}
	
void Start()
{
    if( !guiText )
    {
        Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
        enabled = false;
        return;
    }
    timeleft = updateInterval;  
}
 
void Update()
{
		float pushbutton = Input.GetAxis("ToggleDisplay");
		
		if (pushbutton != 0 && wait ==0)
		{
			wait += Time.deltaTime;//
			displaynumber++;
			displaynumber = displaynumber % 2;
		}
		//adds a .5 second delay between each increment of display number
		if (wait!= 0)
		{
			wait += Time.deltaTime;
			if (wait > .5)
				wait = 0;
		}
		
		switch(displaynumber)
		{
		case 0: 
			//default
			//left side = static observer cam
			//right side = headcam of person
			//no display information
			guiText.text = "OBSERVER CAM";
			break;
		case 1:
			//same layout as default, show fps however
			showfps ();
			break;
		case 2:
			guiText.text = "OBSERVER CAM";
			break;
		case 3:
			showfps ();
		break;
		
		}
		
		
}
	
}