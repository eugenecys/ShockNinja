using UnityEngine;
using System.Collections;

public class load_prologue_level4 : MonoBehaviour {
	// Use this for initialization
	IEnumerator Start () {
		
		yield return new WaitForSeconds (1f);
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		Invoke ("playsound",6);
	}
	
	void playsound()
	{
		Application.LoadLevel (1);
	}
}