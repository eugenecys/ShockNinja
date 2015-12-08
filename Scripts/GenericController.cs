using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericController : MonoBehaviour, Activatable, Activator {
	
	public GameObject activatedArt;
	public GameObject deactivatedArt;
	public AudioClip activateSound;
	public AudioClip deactivateSound;
	public bool permanent;
	public Junction junction;
	private bool activated;
	private AudioSource audiosource;
	public List<Activatable> activatables;
	public GameObject[] activators;
	// Use this for initialization
	void Awake () {
		activatables = new List<Activatable> ();
		audiosource = gameObject.GetComponent<AudioSource> ();
		activated = false;
		if (activatedArt != null) {
			activatedArt.SetActive (false);
		}
		if (deactivatedArt != null) {
			deactivatedArt.SetActive (true);
		}
	}
	
	void Start () {
		foreach (GameObject obj in activators) {
			Activator activator = obj.GetComponent<Activator>();
			if (activator != null) {
				activator.addActivatable (this);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (junction.activated) {
			activate ();
		} else if (!permanent) {
			deactivate();
		}
	}

	public void addActivatable(Activatable act) {
		activatables.Add (act);
	}

	public void activate() {
		if (!activated) {
			on ();
			activateActivatables();
		}
	}
	
	public void deactivate() {
		if (activated) {
			off ();
			deactivateActivatables();
		}
	}

	public void activateActivatables() {
		foreach (Activatable activatable in activatables) {
			if (activatable != null) {
				activatable.activate();
			}
		}
	}
	
	public void deactivateActivatables() {
		foreach (Activatable activatable in activatables) {
			if (activatable != null) {
				activatable.deactivate();
			}
		}
	}

	private void on() {
		activated = true;
		if (activatedArt != null) {
			Debug.Log (activatedArt);
			activatedArt.SetActive (true);
			Debug.Log (activatedArt.activeSelf);
		}
		if (deactivatedArt != null) {
			deactivatedArt.SetActive (false);
		}
		if (activateSound != null && audiosource != null) {
			audiosource.PlayOneShot(activateSound);
		}
	}
	
	private void off() {
		activated = false;
		if (activatedArt != null) {
			activatedArt.SetActive (false);
		}
		if (deactivatedArt != null) {
			deactivatedArt.SetActive (true);
		}
		if (deactivateSound != null && audiosource != null) {
			audiosource.PlayOneShot(deactivateSound);
		}

	}
}
