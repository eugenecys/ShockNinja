using UnityEngine;
using System.Collections;

public class Wire : MonoBehaviour {

	public GameObject activatedWire;
	public GameObject deactivatedWire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate() {
		// Turns on the wire
		deactivatedWire.SetActive (false);

	}

	public void deactivate() {
		// Turns off the wire
		deactivatedWire.SetActive (true);
	}
}
