using UnityEngine;
using System.Collections;

public class power_core_controller : MonoBehaviour {

	//total time is 8 secs
	public float update_time = 3;
	public Color color;

	//[7] is off
	public Sprite[] power_core_sprites;
	public SpriteRenderer r;
	int count;
	//bool change_sprite_flag = true;

	// Use this for initialization
	void Start () {
		r = GetComponents<SpriteRenderer>()[0];
		r.sprite = power_core_sprites[6];
		count = 6;
		Invoke("changelevel" ,8);
	}
	
	
	void changelevel()
	{
		Application.LoadLevel ("level1");
	}

	
	// Update is called once per frame
	void Update () {
		float cur_time = Time.time;
		if ((cur_time > update_time) && (cur_time < (update_time + 0.5f))) {
			update_time += 0.5f;
			if (count >= 0){
				r.sprite = power_core_sprites [count];
				count -= 1;
			}
		}
	}
}
