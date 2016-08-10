using UnityEngine;
using System.Collections;

public class ScreenTabFocus : MonoBehaviour {

	public GameObject[] screens;
	private int selectedScreen =  0;
	public CameraGyroController cameraGyro;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab) ){	
			GameObject screen = screens[selectedScreen];
			selectedScreen= ( selectedScreen+1 ) % screens.Length;
			//Debug.Log ("Pressed tab");
			Vector3 vector = screen.transform.localPosition;
			//Debug.Log("Looking to screen " + screen.name + ": " + vector);
			cameraGyro.LookTo(vector);
		}
	}
}
