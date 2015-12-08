using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LargeConsoleController : MonoBehaviour, Activator {

	public GameObject console1A;
	public GameObject console1D;
	public GameObject console1P;
	public GameObject console2A;
	public GameObject console2D;
	public GameObject console2P;
	public GameObject console3A;
	public GameObject console3D;
	public GameObject console3P;

	private bool poweredOn;

	public Capacitor A;
	public Capacitor B;
	public Capacitor C;

	public AudioClip onSound;
	public AudioClip offSound;
	public AudioClip runSound;

	private List<Activatable> activatables;

	public GameObject indicatorA_on;
	public GameObject indicatorB_on;
	public GameObject indicatorC_on;
	public GameObject indicatorA_off;
	public GameObject indicatorB_off;
	public GameObject indicatorC_off;

	private SpriteRenderer ASR;
	private SpriteRenderer BSR;
	private SpriteRenderer CSR;

	private SpriteRenderer activeSR;

	private AudioSource audioSource;
	// Use this for initialization
	void Awake () {
		activatables = new List<Activatable> ();
	}

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		poweredOn = false;
		console1A.SetActive (false);
		console2A.SetActive (false);
		console3A.SetActive (false);
		console1D.SetActive (true);
		console2D.SetActive (true);
		console3D.SetActive (true);
		console1P.SetActive (false);
		console2P.SetActive (false);
		console3P.SetActive (false);
		indicatorA_off.SetActive (true);
		indicatorB_off.SetActive (true);
		indicatorC_off.SetActive (true);
		indicatorA_on.SetActive (true);
		indicatorB_on.SetActive (true);
		indicatorC_on.SetActive (true);
		ASR = indicatorA_on.GetComponent<SpriteRenderer> ();
		BSR = indicatorB_on.GetComponent<SpriteRenderer> ();
		CSR = indicatorC_on.GetComponent<SpriteRenderer> ();
		ASR.color = new Color (ASR.color.r, ASR.color.g, ASR.color.b, 0);
		BSR.color = new Color (BSR.color.r, BSR.color.g, BSR.color.b, 0);
		CSR.color = new Color (CSR.color.r, CSR.color.g, CSR.color.b, 0);
		activeSR = BSR;
	}
	
	// Update is called once per frame
	void Update () {
		if (!poweredOn) {
			pulse(activeSR);
			bool stateA = A.poweredOn;
			bool stateB = B.poweredOn;
			bool stateC = C.poweredOn;

			if (stateB) {
				activeSR = ASR;
				audioSource.PlayOneShot (onSound);
				console2A.SetActive (true);
				console2D.SetActive (false);
			}
			if (stateA) {
				if (!stateB) {
					audioSource.PlayOneShot (offSound);
					console2A.SetActive (false);
					console2D.SetActive (true);
					A.poweredOn = false;
					B.poweredOn = false;
				} else {
					activeSR = CSR;
					audioSource.PlayOneShot (onSound);
					console1A.SetActive (true);
					console1D.SetActive (false);
				}
			}
			if (stateC) {
				if (!stateB || !stateA) {
					audioSource.PlayOneShot (offSound);
					console1A.SetActive (false);
					console1D.SetActive (true);
					console2A.SetActive (false);
					console2D.SetActive (true);
					A.poweredOn = false;
					B.poweredOn = false;
					C.poweredOn = false;
				} else {
					activeSR = null;
					audioSource.PlayOneShot (onSound);
					console3A.SetActive (true);
					console3D.SetActive (false);
				}

			}

			if (!stateA && !stateB && !stateC) {
				activeSR = BSR;
			}

			if (stateA && stateB && stateC) {
				poweredOn = true;
				console1A.SetActive (false);
				console2A.SetActive (false);
				console3A.SetActive (false);
				console1D.SetActive (false);
				console2D.SetActive (false);
				console3D.SetActive (false);
				console1P.SetActive (true);
				console2P.SetActive (true);
				console3P.SetActive (true);
			}
		} else {
			if (!audioSource.isPlaying) {
				audioSource.PlayOneShot(runSound);
			}
			activateActivatables();
		}
	}

	public void addActivatable(Activatable act) {
		activatables.Add(act);
	}

	public void activateActivatables() {
		foreach (Activatable activatable in activatables) {
			activatable.activate();
		}
	}

	public void deactivateActivatables() {
		foreach (Activatable activatable in activatables) {
			activatable.deactivate();
		}
	}

	private void pulse(SpriteRenderer asr) {
		if (asr != null) {
			asr.color = new Color (asr.color.r, asr.color.g, asr.color.b, Mathf.Abs (Mathf.Sin (Time.time * 4)));
		}
	}
}
