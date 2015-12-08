using UnityEngine;
using System.Collections;

public class load_prologue_level2 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Invoke ("level",6);
	}
	
	void level()
	{
		Application.LoadLevel (2);
	}
}