using UnityEngine;
using System.Collections;

public class Constants {
	
	public static int NodeStoredPower = 15;
	public static int CapacitorPowerLimit = 180;
	public static float WireWidth = 0.05f;
	public static float NodeTriggerProximity = 0.4f;
	public static float KinectSensitivity = 1f;
	public static int SmoothDepth = 5;
	public static float NextStagePadProximity = 2f;
	public static float UpdateLineRendererThreshold = 0.05f;
	public static float parallexMultiplier = 0.05f;
	public static class Depths {
		public static float HiddenObject = 2f;
		public static float Foreground = 1f;
		public static float BackgroundObject = 2f;
		public static float ForegroundObject = 0f;
		public static float VisibleObject = -1f;
	}
}
