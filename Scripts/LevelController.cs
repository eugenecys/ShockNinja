using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject player;
	public bool stageComplete { get; private set; }
	private Vector3 initialPos;
	private float translateStep = 0.04f;
	private float smoothingCoeff = 1.0f;
	private Vector3 nextPos;
	// Use this for initialization
	void Awake () {
		initialPos = transform.position;
	}


	IEnumerator slide() {
		Vector3 direction = Vector3.Normalize(nextPos - transform.position);
		while ((transform.position - nextPos).magnitude > 0.1f) {
			transform.position += direction * 0.05f;
			yield return null;
		}
	}


	public void goTo(Vector3 next) {
		nextPos = next;
		StartCoroutine ("slide");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
