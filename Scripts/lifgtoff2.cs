﻿using UnityEngine;
using System.Collections;

public class lifgtoff2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 6);
	}
	
	// Update is called once per frame
	void destroy () {
		Destroy (gameObject);
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
