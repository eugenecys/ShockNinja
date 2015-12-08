using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour, Connector, Hideable, Activator {

	public Node[] nodes;
	public Junction[] junctions;
	private Connector[] connectors;
	private List<Activatable> activatables;
	private LineRenderer linerenderer;
	public int currentPower { get; private set; }
	public bool activated { get; private set; }
	public Material deactivatedMat;
	public Material activatedMat;
	public int storedPower;
	public AudioClip activateSound;
	public AudioClip deactivateSound;
	private AudioSource audioSource;
	//private bool poweringDown;
	private bool markForDeactivation;
	private bool markForActivation;

	public GameObject activatedNode;
	public GameObject deactivatedNode;
	public GameObject darkNode;
	public bool defaultDark;
	public bool activatable;
	public GameObject activator;
	public bool scanning;
	public GameObject scanner;
	// Use this for initialization
	void Awake () {
		if (scanner != null) {
			scanner.SetActive(scanning);
		}

		if (storedPower == 0) {
			storedPower = Constants.NodeStoredPower;
		}
		if (darkNode != null) {
			if (defaultDark) {
				darkNode.SetActive (true);
			} else {
				darkNode.SetActive (false);
			}
		}

		initConnectors (); 
		initLineRenderer ();
		audioSource = gameObject.GetComponent<AudioSource> ();
		activatables = new List<Activatable> ();
		//poweringDown = false;
		markForDeactivation = false;
		markForActivation = false;

		powerOff ();
		currentPower = 0;
	}

	void Start() {
		if (activatable) {
			if (activator != null) {
				Activator act = activator.GetComponent<Activator>();
				if (act != null) {
					act.addActivatable(this);
				}
			}
		}
	}

	void initConnectors() {
		connectors = new Connector[nodes.Length + junctions.Length];
		int count = 0;
		foreach (Node node in nodes) {
			connectors[count] = node;
			count++;
		}
		foreach (Junction junction in junctions) {
			connectors[count] = junction;
			count++;
		}
	}

	void initLineRenderer() {
		linerenderer = gameObject.GetComponent<LineRenderer> ();
		if (linerenderer == null) {
			linerenderer = gameObject.AddComponent<LineRenderer> ();
		}
		linerenderer.material = deactivatedMat;
		linerenderer.SetWidth (Constants.WireWidth, Constants.WireWidth);
		linerenderer.SetVertexCount (connectors.Length * 2);
		for (int i = 0; i < connectors.Length; i++) {
			linerenderer.SetPosition(2 * i, transform.position);
			linerenderer.SetPosition(2 * i + 1, connectors[i].getPosition());
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < connectors.Length; i++) {
			linerenderer.SetPosition(2 * i, transform.position);
			linerenderer.SetPosition(2 * i + 1, connectors[i].getPosition());
			connectors[i].updateLines();
		}
		if (activated) {
			currentPower -= 1;

			if (currentPower <= 0) {
				deactivate();
			}
		}
	}

	public void updateLines() {
		for (int i = 0; i < connectors.Length; i++) {
			linerenderer.SetPosition(2 * i, transform.position);
			linerenderer.SetPosition(2 * i + 1, connectors[i].getPosition());
		}
	}

	public void activate() {
		activate (storedPower);
	}
	
	public void activate(int power) {
		// Turns on the node
		if (!markForActivation) {
			markForActivation = true;
			foreach(Connector connector in connectors) {
				connector.activate();
			}
			markForActivation = false;
		}

		currentPower = power;
		if (!activated) {
			powerOn();
		}
		
	}

	public void trigger(int power) {
		// Turns on the node
		if (!markForActivation) {
			markForActivation = true;
			foreach(Connector connector in connectors) {
				connector.activate();
			}
			markForActivation = false;
		}

		currentPower = power;
		if (!activated) {
			powerOn();
		}
	}

	public void trigger() {
		trigger (Constants.NodeStoredPower);
	}

	public void deactivate() {
		if (!markForDeactivation) {
			markForDeactivation = true;
			foreach(Connector connector in connectors) {
				connector.deactivate();
			}
			markForDeactivation = false;
		}
		
		if (activated) {
			powerOff();
		}
	}

	public void addActivatable(Activatable act) {
		activatables.Add (act);
	}

	public void activateActivatables () {
		foreach (Activatable actb in activatables) {
			actb.activate();
		}
	}

	public void deactivateActivatables () {
		foreach (Activatable actb in activatables) {
			actb.deactivate();
		}
	}

	private void powerOn() {
		// Turns on the node
		activated = true;
		if (activateSound != null && audioSource != null) {
			audioSource.PlayOneShot(activateSound);
		}
		linerenderer.material = activatedMat;
		deactivatedNode.SetActive (false);
		activatedNode.SetActive (true);
	}

	private void powerOff() {
		// Turns off the node
		activated = false;
		if (deactivateSound != null && audioSource != null) {
			audioSource.PlayOneShot(deactivateSound);
		}
		linerenderer.material = deactivatedMat;
		deactivatedNode.SetActive (true);
		activatedNode.SetActive (false);

	}

	public void hide() {
		darkNode.SetActive (true);
	}

	public void unhide() {
		darkNode.SetActive (false);
	}
			
	public Vector3 getPosition() {
		return transform.position;
	}
}
