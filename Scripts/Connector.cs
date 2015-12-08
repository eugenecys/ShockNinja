using UnityEngine;
using System.Collections;

public interface Connector : Activatable {

	Vector3 getPosition();
	void updateLines();

}
