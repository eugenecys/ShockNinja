using UnityEngine;
using System.Collections;

public class load_prologue_level1 : MonoBehaviour {

	void start()
	{
		Invoke("changelevel" ,12);
	}


	void changelevel()
	{
		Application.LoadLevel (1);
	}
}
