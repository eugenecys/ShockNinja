using UnityEngine;
using System.Collections;

public class BodyPartController : MonoBehaviour {

	public GameObject kinectObject;
	private int smoothLevel = Constants.SmoothDepth;
	private int circularWindowIdx;
	private Vector2[] circularWindow = new Vector2[Constants.SmoothDepth];
	// Use this for initialization
	void Start () {
		circularWindowIdx = 0;
		Vector3 pos = kinectObject.transform.position;
		for (int i = 0; i < smoothLevel; i++) {
			circularWindow[i] = new Vector2(pos.x * Constants.KinectSensitivity, pos.y * Constants.KinectSensitivity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = kinectObject.transform.position * Constants.KinectSensitivity;
		circularWindow [circularWindowIdx] = new Vector2 (pos.x, pos.y);
		circularWindowIdx = (circularWindowIdx + 1) % smoothLevel;
		Vector2 newPos = new Vector2 (0, 0);
		foreach (Vector2 prevPos in circularWindow) {
			newPos += prevPos;
		}
		newPos = newPos / smoothLevel;
		transform.position = new Vector3 (newPos.x, newPos.y, transform.position.z);
	}
}
