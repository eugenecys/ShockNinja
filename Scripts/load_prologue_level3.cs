using UnityEngine;
using System.Collections;

public class load_prologue_level3 : MonoBehaviour {
	// Use this for initialization

	public SpriteRenderer rend;
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		//Invoke ("change", 3);
		Invoke ("level",5);
	}
	
	void level()
	{
		Application.LoadLevel ("level3");
	}



}