using UnityEngine;
using System.Collections;

public class Utility {

	public static float Distance2D(Vector3 a, Vector3 b) {
		return Mathf.Sqrt(Mathf.Pow (a.x - b.x, 2) + Mathf.Pow (a.y - b.y, 2));
	}
}
