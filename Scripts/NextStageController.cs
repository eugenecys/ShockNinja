using UnityEngine;
using System.Collections;

public class NextStageController : MonoBehaviour {

	public GameObject player;
	public GameObject level;
	public string nextStage;
	public bool translateStage;
	public float translateDistance;
	private Vector3 initialPos;
	private float translateStep = 0.02f;
	public AudioClip nextStageSound;
	private AudioSource nextStagePlayer;
	private float initialTime;
	private float doorDelay;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
		doorDelay = 5.0f;
		initialPos = level.transform.position;
		nextStagePlayer = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (initialTime + doorDelay < Time.time) {
			initialTime = Time.time;
			if (nextStagePlayer != null && nextStageSound != null) {
				nextStagePlayer.PlayOneShot(nextStageSound);
			}
		}

		float dist = Utility.Distance2D(player.transform.position, transform.position);
		if (dist < Constants.NextStagePadProximity) {
			// Go next stage
			if (translateStage) {
				Debug.Log ("Translate stage");
				StartCoroutine("slideLeft");

			} else {
				//Application.LoadLevel(nextStage);
				Debug.Log ("Next stage");
			}
		}
	}


}
