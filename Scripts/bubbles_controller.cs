using UnityEngine;
using System.Collections;

public class bubbles_controller : MonoBehaviour {

	public SpriteRenderer[] rend;
	// Use this for initialization
	void Start () {
		rend = GetComponents<SpriteRenderer>();
		Debug.Log ("lalala");
		Debug.Log(rend.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
