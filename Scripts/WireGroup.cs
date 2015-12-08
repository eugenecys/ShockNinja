using UnityEngine;
using System.Collections;

public class WireGroup : MonoBehaviour {

	public Wire[] wires;
	public Junction[] junctions;
	public Node[] nodes;

	public bool activated { get; private set; }

	// Use this for initialization
	void Awake () {
		activated = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void addWire(Wire wire) {
	}

	public void activate() {
		if (!activated) {
			foreach (Wire wire in wires) {
				wire.activate ();
			}
			foreach (Junction junction in junctions) {
				junction.activate ();
			}
			foreach (Node node in nodes) {
				node.activate ();
			}
			activated = true;
		}
	}

	public void deactivate() {
		if (activated) {
			foreach (Wire wire in wires) {
				wire.deactivate ();
			}
			foreach (Junction junction in junctions) {
				junction.deactivate ();
			}
			foreach (Node node in nodes) {
				node.deactivate ();
			}
			activated = false;
		}
	}
}
