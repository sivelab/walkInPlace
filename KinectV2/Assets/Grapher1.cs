using UnityEngine;
using System.Collections;

public class Grapher1 : MonoBehaviour {
	[Range(10,100)]
	public int resolution = 60;
	public Transform head;
	public float timeIncrement = 0.5f;
	public int xyOrz; // x = 0, y = 1, z = 1

	private int currentResolution;
	private ParticleSystem.Particle[] points;
	private float sec;
	// Use this for initialization
	void Start () {
		CreatePoints();
		sec = 0;
	}

	private void CreatePoints () {
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution];
		float increment = 1f / (resolution - 1);
		for (int i = 0; i < resolution; i++)
		{
			float x = i * increment;
			points[i].position = new Vector3(x,0f,0f);
			if (xyOrz ==0){
				points[i].color = new Color (255f, 0f, 0f);

			}
			else if (xyOrz == 1){
				points[i].color = new Color (0f, 255f, 0f);

			}
			else if (xyOrz == 2){
				points[i].color = new Color (0f, 0f, 255f);

			}
			points[i].size = 0.01f;
			
		}
	
	
	}

	// Update is called once per frame
	void Update () {
		if (currentResolution != resolution || points == null)
		{
			CreatePoints ();
		}
		sec += Time.deltaTime;
		if(sec > timeIncrement)
			{
			sec = 0;
			Vector3 p = points[points.Length-1].position;
			if(xyOrz == 0)
			{
				p.y = head.localPosition.x/10;

			}
			else if (xyOrz == 1)
			{
				p.y = head.localPosition.y/10;

			}
			else if (xyOrz == 2)
			{
				p.y = head.localPosition.z/10;

			}
			Debug.Log(p.y);
			points[points.Length-1].position = p;
			for (int i = 0; i < points.Length-1; i++)
			{
				Vector3 p2 = points[i].position;
				p2.y = points[i+1].position.y;
				points[i].position = p2;

			}
		}
		particleSystem.SetParticles(points, points.Length);
	}
}
