using UnityEngine;
using System.Collections;

public class help_up_riht_2 : MonoBehaviour {
	public SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		Invoke ("change", 2.0f);
	}
	
	
	void change()
	{
		rend = GetComponent<SpriteRenderer>();
		rend.enabled = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}