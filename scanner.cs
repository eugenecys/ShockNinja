using UnityEngine;
using System.Collections;

public class scanner : MonoBehaviour {

	private float initialTime;
	private float delay = 3.0f;

	private int count;
	private Vector3 initialPos;
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 0.75f);
		count = 0;
		initialPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Sin (count * Mathf.PI / 60);

		Debug.Log ("D: " + count.ToString () + " E: " + x.ToString ());
		if (x < 0) {
			x = 0;
		}

		count ++;
		transform.localPosition = new Vector3 (((1.0f * count % 60) / 60) * 0.25f + initialPos.x, transform.localPosition.y, transform.localPosition.z);
		transform.localScale = new Vector3 (x * 0.15f, transform.localScale.y, transform.localScale.z);
	}
}
