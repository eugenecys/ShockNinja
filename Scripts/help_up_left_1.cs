using UnityEngine;
using System.Collections;

public class help_up_left_1 : MonoBehaviour {
	public SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		Invoke ("change", 1.4f);
	}
	
	
	void change()
	{
		rend = GetComponent<SpriteRenderer>();
		rend.enabled = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}