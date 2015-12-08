using UnityEngine;
using System.Collections;

public class Circuit : MonoBehaviour {

	public Node[] nodes;
	public Node[] plugs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < nodes.Length; i++) {
			for (int j = 0; j < plugs.Length; j++ ){
				if (Utility.Distance2D(nodes[i].transform.position, plugs[j].transform.position) < Constants.NodeTriggerProximity) {
					if (nodes[i].activated && !plugs[j].activated) {
						plugs[j].activate(nodes[i].currentPower);
					} else if (plugs[j].activated && !nodes[i].activated) {
						nodes[i].activate(plugs[j].currentPower);
					} else if (nodes[i].activated && plugs[j].activated) {
						if (nodes[i].currentPower > plugs[j].currentPower) {
							plugs[j].activate (nodes[i].currentPower);
						} else {
							nodes[i].activate (plugs[j].currentPower);
						}
					}
				}
			}
		}
	}
}
