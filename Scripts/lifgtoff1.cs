using UnityEngine;
using System.Collections;

public class lifgtoff1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroy", 4);
	}
	
	// Update is called once per frame
	void destroy () {
		Destroy (gameObject);
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
}
