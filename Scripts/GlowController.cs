using UnityEngine;
using System.Collections;

public class GlowController : MonoBehaviour {

	public float glowDelay;
	public float initialScale;
	public float finalScale;
	private float initialTime;
	public float scaleStep;
	public AudioClip glowSound;
	private AudioSource glowPlayer;
	public Node monitor;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
		if (glowDelay <= 0) {
			glowDelay = 3.0f;
		}
		if (initialScale <= 0) {
			initialScale = transform.localScale.x;
		}
		if (finalScale <= 0) {
			finalScale = 1;
		}
		if (scaleStep <= 0) {
			scaleStep = 0.003f;
		}
		glowPlayer = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (initialTime + glowDelay < Time.time) {
			initialTime = Time.time;
			StartCoroutine("glow");
			if (glowSound != null) {
				glowPlayer.PlayOneShot(glowSound);
			}
		}

		if (monitor != null) {
			if(monitor.activated) {
				gameObject.SetActive(false);
			}
		}
	}

	
	IEnumerator glow() {
		while (transform.localScale.x < finalScale) {
			transform.localScale = new Vector3(transform.localScale.x + scaleStep, transform.localScale.y + scaleStep, transform.localScale.z);
			yield return null;
		}
		transform.localScale = new Vector3(initialScale, initialScale, transform.localScale.z);
	}
}
