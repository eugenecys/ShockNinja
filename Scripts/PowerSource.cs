﻿using UnityEngine;
using System.Collections;

public class PowerSource : MonoBehaviour {

	public Junction junction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		junction.activate ();
	}
}
