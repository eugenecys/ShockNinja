using UnityEngine;
using System.Collections;

public class city_shut_off : MonoBehaviour {
	
	//total time is 6 secs
	public float update_time = 0;
	public Color color;
	public float start_time;
	
	//[5] is off
	public Sprite[] city_light_sprites;
	public SpriteRenderer r;
	int count;
	//bool change_sprite_flag = true;
	
	// Use this for initialization
	void Start () {
		start_time = Time.time;
		r = GetComponents<SpriteRenderer>()[0];
		r.sprite = city_light_sprites[4];
		count = 3;
		Invoke("changelevel" ,6);
	}
	
	
	void changelevel()
	{
		Application.LoadLevel ("level2");
	}
	
	
	// Update is called once per frame
	void Update () {
		float cur_time = Time.time;
		if ((cur_time > start_time + update_time) && (cur_time < (start_time + update_time + 1f))) {
			update_time += 1f;
			if (count >= 0){
				r.sprite = city_light_sprites [count];
				count -= 1;
			}
		}
	}
}
