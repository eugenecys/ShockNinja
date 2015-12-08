using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Activator {

	void activateActivatables();
	void deactivateActivatables();
	void addActivatable(Activatable activatable);
}
