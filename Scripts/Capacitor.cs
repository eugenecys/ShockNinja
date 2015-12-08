using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Capacitor : MonoBehaviour, Activatable, Activator {

	public Junction junction;
	private LineRenderer linerenderer;
	public int currentPower { get; private set; }
	public bool activated { get; private set; }
	public Material deactivatedMat;
	public Material activatedMat;
	public int powerLimit;
	public AudioClip activateSound;
	public AudioClip deactivateSound;
	private AudioSource audioSource;
	public bool poweredOn;
	private bool markForDeactivation;
	private bool markForActivation;
	public GameObject[] capacitorLevels;
	public AudioClip[] levelSounds;
	private int activeIdx;
	private List<Activatable> activatables;

	// Use this for initialization
	void Awake () {
		activatables = new List<Activatable> ();
		for (int i = 1; i < capacitorLevels.Length; i++) {
			capacitorLevels[i].SetActive(false);
		}
		activeIdx = 0;
		poweredOn = false;
		if (powerLimit == 0) {
			powerLimit = Constants.CapacitorPowerLimit;
		}
		audioSource = gameObject.GetComponent<AudioSource> ();
		//poweringDown = false;
		markForDeactivation = false;
		markForActivation = false;

		currentPower = 0;
	}

	// Update is called once per frame
	void Update () {
		if (!poweredOn) {
			if (junction.activated) {
				activate ();
				currentPower += 1;
				if (currentPower >= powerLimit) {
					currentPower = powerLimit;
					powerOn ();
				} else {
					int level = (int)(1.0f * currentPower / powerLimit * (capacitorLevels.Length - 1));
					if (activeIdx != level) {
						setLevel (level);
					}
				}
			} else {
				deactivate ();
				if (currentPower > 0) {
					currentPower -= 1;
				}
				int level = (int)Mathf.Floor (1.0f * currentPower / powerLimit * capacitorLevels.Length);
				if (activeIdx != level) {
					setLevel (level);
				}
			}
		} else {
			activateActivatables ();
		}
	}

	public void activateActivatables () {
		foreach (Activatable act in activatables) {
			act.activate();
		}
	}

	public void deactivateActivatables() {

	}

	public void addActivatable(Activatable act) {
		activatables.Add (act);
	}

	public void activate() {
		// Turns on the node
		activated = true;
	}

	public void deactivate() {
		activated = false;
	}

	private void powerOn() {
		if (!poweredOn) {
			// Turns on the node
			activated = true;
			poweredOn = true;
			setLevel (capacitorLevels.Length - 1);
		}
	}

	private void setLevel(int idx) {
		capacitorLevels [activeIdx].SetActive (false);
		capacitorLevels [idx].SetActive (true);
		if (idx > 0) {
			if (levelSounds[idx - 1] != null) {
				audioSource.PlayOneShot (levelSounds [idx - 1]);
			}
		}
		activeIdx = idx;
	}

	public Vector3 getPosition() {
		return transform.position;
	}
}
