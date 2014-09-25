using UnityEngine;
using System.Collections;
using OVR;

public class SenseTap : MonoBehaviour {
	public GameObject box;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Detect a moderate tap on the side of the HMD.
		Hmd hmd = Hmd.GetHmd();
		ovrTrackingState ts = hmd.GetTrackingState();
		if ((ts.StatusFlags & (uint)ovrStatusBits.ovrStatus_OrientationTracked) != 0)
		{
			Vector3 v = OVRExtensions.ToVector3(ts.RawSensorData.Accelerometer);
			// Arbitrary value and representing moderate tap on the side of the DK2 Rift.
			if (v.sqrMagnitude > 250.0f) {
				Instantiate(box, box.transform.position, box.transform.rotation);
			}
		}
	}
}
