using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamerawechsel : MonoBehaviour {

	[Header("Cameras on Keys 1-6")]
	public Camera[] Kamera = new Camera[6];
	//public Camera Kamera2, Kamera3, Kamera4, Kamera5, Kamera6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Key 1
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ActivateCameras (1);
		// Key 2
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ActivateCameras (2);
		// Key 3
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ActivateCameras (3);
		// Key 4
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ActivateCameras (4);
		// Key 5
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ActivateCameras (5);
		// Key 6
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			ActivateCameras (6);
		}
	}

	void ActivateCameras(int number)
	{
		if (number > 0 && number <= Kamera.Length)
			for (int id = 0; id < Kamera.Length; id++) {
				if (Kamera [id] != null)
					Kamera [id].enabled = (id + 1) == number;
			}
	}
}
