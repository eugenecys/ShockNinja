﻿using UnityEngine;
using System.Collections;

public class help_right_3 : MonoBehaviour {
	public SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		Invoke ("change", 1.6f);
	}
	
	
	void change()
	{
		rend = GetComponent<SpriteRenderer>();
		rend.enabled = true;
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}