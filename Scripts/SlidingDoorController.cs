using UnityEngine;
using System.Collections;

public class SlidingDoorController : MonoBehaviour, Activatable {

	public GameObject door;
	public bool permanent;
	public float doorSize;
	public float doorStep;
	public Junction junction;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
	private AudioSource audioSource;
	private bool opened;
	private float initialT;
	private float offsetThreshold = 0.01f;
	private float initialStep = 0;
	public string doorDirection;
	private Vector2 dir;
	public LevelController level;
	public Vector3 nextPosition;
	public bool changeStage;
	public string stageName;
	// Use this for initialization
	void Start () {
		if (doorStep <= 0.04f) {
			doorStep = 0.04f;
		}
		switch (doorDirection.ToLower()) {
		case "left":
			dir = new Vector2(-1, 0);
			break;
		case "right":
			dir = new Vector2(1, 0);
			break;
		default:
		case "up":
			dir = new Vector2(0, 1);
			break;
		case "down":
			dir = new Vector2(0, -1);
			break;
		}
		initialT = door.transform.position.x * Mathf.Abs(dir.x) + door.transform.position.y * Mathf.Abs(dir.y);
		audioSource = gameObject.GetComponent<AudioSource> ();
		opened = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (junction.activated) {
			activate ();
		} else if (!permanent) {
			deactivate();
		}
	}

	public void activate() {
		if (!opened) {
			opened = true;

			initialStep = 0;
			if (doorOpenSound != null) {
				audioSource.PlayOneShot(doorOpenSound);
			}
			StartCoroutine("open");
		}
	}

	public void deactivate() {
		if (opened) {
			opened = false;
			initialStep = 7 * Mathf.PI / 4;
			if (doorCloseSound != null) {
				audioSource.PlayOneShot(doorCloseSound);
			}
			StartCoroutine("close");
		}
	}

	private float runFunc(float x) {
		float y = (Mathf.Exp (x) * Mathf.Sin (x)) / (Mathf.Exp (7 * Mathf.PI / 4) * Mathf.Sin (7 * Mathf.PI / 4));
		return y;
	}

	IEnumerator open() {
		while (initialStep < 7 * Mathf.PI / 4) {
			float doorT = runFunc(initialStep);
			initialStep += doorStep;
			door.transform.position = new Vector3(door.transform.position.x * Mathf.Abs (dir.y) + Mathf.Abs(dir.x) * initialT + doorT * doorSize * dir.x, 
			                                      door.transform.position.y * Mathf.Abs (dir.x) + Mathf.Abs(dir.y) * initialT + doorT * doorSize * dir.y, 
			                                      door.transform.position.z);
			yield return null;
		}
		if (changeStage) {
			if (stageName != null && stageName.Length > 0) {
				Application.LoadLevel(stageName);
			}
		} else {
			level.goTo (nextPosition);
		}
	}

	IEnumerator closeHorizontal() {
		while (initialStep > 0) {
			float doorT = runFunc(initialStep);
			initialStep -= doorStep;
			door.transform.position = new Vector3(door.transform.position.x * Mathf.Abs (dir.y) + Mathf.Abs(dir.x) * initialT + doorT * doorSize * dir.x, 
			                                      door.transform.position.y * Mathf.Abs (dir.x) + Mathf.Abs(dir.y) * initialT + doorT * doorSize * dir.y, 
			                                      door.transform.position.z);
			yield return null;
		}
	}

}
