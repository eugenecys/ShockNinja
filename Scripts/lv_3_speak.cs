using UnityEngine;
using System.Collections;

public class lv_3_speak : MonoBehaviour {
	public SpriteRenderer r;
	// Use this for initialization
	void Start () {
		Invoke ("change", 0.5f);
		Invoke ("level",3);
	}
	
	
	void change()
	{
		r = GetComponent<SpriteRenderer>();
		r.enabled = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}

	void level() {
		Application.LoadLevel ("start");
	}
}