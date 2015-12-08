using UnityEngine;
using System.Collections;

public class CityController : MonoBehaviour {

	public GameObject[] cityLights;
	public GameObject city;
	public GameObject background;

	private float[] switchValues = new float[]{0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1};

	private SpriteRenderer[] cityRenderers;
	private int frame;

	public SpriteRenderer saved;
	// Use this for initialization
	void Start () {
		frame = 0;
		cityRenderers = new SpriteRenderer[cityLights.Length];
		for (int i = 0; i < cityLights.Length; i++) {
			cityRenderers[i] = cityLights[i].GetComponent<SpriteRenderer>();
			Color ca = cityRenderers[i].color;
			cityRenderers[i].color = new Color(ca.r, ca.g, ca.b, 0);
		}
		saved.color = new Color (saved.color.r, saved.color.g, saved.color.b, 0);

	}
	
	// Update is called once per frame	
	void Update () {
		for (int i = 0; i < cityRenderers.Length; i++) {
			Color cityColor = cityRenderers [i].color;
			if (frame / 3 - i * 20 >= switchValues.Length) {
				cityRenderers [i].color = new Color (cityColor.r, cityColor.g, cityColor.b, 1);
			} else if (frame / 3 - i * 20 > 0) {
				cityRenderers [i].color = new Color (cityColor.r, cityColor.g, cityColor.b, switchValues [frame / 3 - i * 20]);
			} 
		}
		frame++;
		if (frame < 830) {
			city.transform.Translate (Vector3.left * 0.055f);
			background.transform.Translate (Vector3.left * 0.02f);
		}

		if (frame > 300 && frame < 400) {
			saved.color = new Color(saved.color.r, saved.color.g, saved.color.b, 0.01f * (frame - 300));
		}
	}
}
