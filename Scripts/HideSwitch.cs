using UnityEngine;
using System.Collections;
public class HideSwitch : MonoBehaviour, Activatable {

	public GameObject[] triggers;
	public Hideable[] hideables;

	// Use this for initialization
	void Awake () {
		hideables = gameObject.GetComponentsInChildren<Hideable> ();
		deactivate ();
	}

	void Start () {
		foreach (GameObject obj in triggers) {
			Activator activator = obj.GetComponent<Activator>();
			if (activator != null) {
				activator.addActivatable (this);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void activate() {
		transform.position = new Vector3 (transform.position.x, transform.position.y, Constants.Depths.VisibleObject);
		foreach (Hideable hideable in hideables) {
			hideable.unhide();
		}
	}

	public void deactivate() {
		transform.position = new Vector3 (transform.position.x, transform.position.y, Constants.Depths.HiddenObject);
		foreach (Hideable hideable in hideables) {
			hideable.hide();
		}
	}
}
