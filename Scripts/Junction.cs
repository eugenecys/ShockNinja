using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Junction : MonoBehaviour, Connector {

	public Node[] nodes;
	public Junction[] junctions;
	public Connector[] connectors;
	private LineRenderer linerenderer;
	public Material deactivatedMat;
	public Material activatedMat;
	//public static int storedPower = 3;
	//private int currentPower;
	//public bool repeat = true;
	//public WireGroup[] wiregroups;
	public bool activated { get; private set; }
	private bool markForDeactivation;
	private bool markForActivation;
	public GameObject activatedJunction;
	public GameObject deactivatedJunction;

	private Vector3 lastPos;
	// Use this for initialization
	void Awake () {
		lastPos = transform.position;
		initConnectors ();
		initLineRenderer ();
		markForDeactivation = false;
		//currentPower = 0
		powerOff ();
	}

	public void updateLines() {
		for (int i = 0; i < connectors.Length; i++) {
			linerenderer.SetPosition (2 * i, transform.position);
			linerenderer.SetPosition (2 * i + 1, connectors [i].getPosition ());
		}
	}

	// Update is called once per frame
	void Update () {
		/*
		if (activated) {
			if (markForDeactivation) {
				currentPower -= 1;
			}

			if (currentPower <= 0) {
				currentPower = 0;
				activated = false;
				foreach (WireGroup wiregroup in wiregroups) {
					if (wiregroup.activated) {
						wiregroup.deactivate();
					}
				}
			}
		}*/
		if ((transform.position - lastPos).magnitude > Constants.UpdateLineRendererThreshold) {
			for (int i = 0; i < connectors.Length; i++) {
				linerenderer.SetPosition (2 * i, transform.position);
				linerenderer.SetPosition (2 * i + 1, connectors [i].getPosition ());
				connectors[i].updateLines();
			}
			lastPos = transform.position;
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

	public void activate() {
		if (!markForActivation) {
			markForActivation = true;
			foreach(Connector connector in connectors) {
				if(connector != null) {
					connector.activate();
				}
			}
			markForActivation = false;
		}

		if (!activated) {
			powerOn();
		}
		/*
		currentPower = storedPower;
		markForDeactivation = false;
		// Turns on the junction
		if (!activated) {
			powerOn ();
			foreach (WireGroup wiregroup in wiregroups) {
				if (!wiregroup.activated) {
					wiregroup.activate();
				}
			}
		}*/
	}
	
	public void deactivate() {
		//markForDeactivation = true;
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

	private void powerOn() {
		linerenderer.material = activatedMat;
		activated = true;
		deactivatedJunction.SetActive (false);
		activatedJunction.SetActive (true);
	}

	private void powerOff() {
		activated = false;
		linerenderer.material = deactivatedMat;
		deactivatedJunction.SetActive (true);
		activatedJunction.SetActive (false);
	}

	public Vector3 getPosition() {
		return transform.position;
	}
}
