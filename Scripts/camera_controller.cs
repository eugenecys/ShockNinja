using UnityEngine;
using System.Collections;

public class camera_controller : MonoBehaviour {

	//canera oan from x = 9.77 to x = -9.48
	//from time = 0.5s to time = 4.5s
	public Camera c;
	public float spd = (16.73f+3.14f)/4f;
	public float start_time;

	// Use this for initialization
	void Start () {
		c = GetComponents<Camera>()[0];
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float cur_time = Time.time;
		if ((cur_time >= (start_time+0.5f)) && (cur_time <= (start_time+4.5f)))
			c.transform.position += Vector3.left * spd * Time.deltaTime;
	}
}
