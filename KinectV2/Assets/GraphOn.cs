using UnityEngine;
using System.Collections;

public class GraphOn : MonoBehaviour {
	
	bool menuOpen = false;
	float menuOpenTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Menu") > 0)
		{
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
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(true);
			}
		}
		else
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive(false);
			}
		}
	}
}
