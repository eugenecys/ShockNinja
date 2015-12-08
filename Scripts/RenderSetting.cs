using UnityEngine;
using System.Collections;

public class RenderSetting : MonoBehaviour {

	public bool render;
	public bool attach;

	// Use this for initialization
	void Start () {
		if (!render) {
			MeshRenderer pmr = gameObject.GetComponent<MeshRenderer>();
			if (pmr != null) {
				pmr.enabled = false;
			}
			MeshRenderer[] mrs = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach(MeshRenderer mr in mrs) {
				mr.enabled = false;
			}
		}
		if (!attach) {
			BodyPartController[] bdc = gameObject.GetComponentsInChildren<BodyPartController>();
			foreach(BodyPartController bd in bdc) {
				bd.enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
