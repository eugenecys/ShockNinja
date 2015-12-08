using UnityEngine;
using System.Collections;

public class PowerCore : MonoBehaviour {

	public Node node1;
	public Node node2;
	public Node node3;
	public Node node4;

	public Node node;

	public Capacitor powerCore;

	private float initialTime;
	private bool poweredOn;
	private float deltaTime = 2.0f;

	void Start () {
		poweredOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (node1.activated && node2.activated && node3.activated && node4.activated) {
			node.activate();
		}

		if (!poweredOn) { 
			if (powerCore.poweredOn) {
				poweredOn = true;
				initialTime = Time.time;
			}
		} else {
			if (initialTime + deltaTime < Time.time) {
				Application.LoadLevel("end_scene");
			}
		}
	}
}
