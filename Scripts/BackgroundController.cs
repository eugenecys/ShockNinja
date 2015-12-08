using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public GameObject[] backgrounds;
	private Vector3[] backgroundInitialPos;
	public GameObject foreground;
	public GameObject player;
	public Vector3 prevPos;
	// Use this for initialization
	void Awake () {
		prevPos = foreground.transform.position;
		backgroundInitialPos = new Vector3[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			backgroundInitialPos[i] = backgrounds[i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = foreground.transform.position;
		if ((pos - prevPos).magnitude > 0.05f) {
			float dist = pos.x - prevPos.x;
			for (int i = 0; i < backgrounds.Length; i++) {
				backgrounds[i].transform.Translate(Vector3.right * dist * (i + 1) * Constants.parallexMultiplier);
			}
			prevPos = foreground.transform.position;
		}

	}
}
