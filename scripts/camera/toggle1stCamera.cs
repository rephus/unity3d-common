using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggle1stCamera : MonoBehaviour {
	
	GameObject camera;
	public bool active;
	public Vector3 position3rd = new Vector3(0,3,-10);
	private Vector3 initialPosition ;

	// Use this for initialization
	void Start () {
		
		camera = GameObject.Find("CameraGyro");
		initialPosition = camera.transform.localPosition;

		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { Toggle(); });
		
		if(active) Enable1st();
		else Enable3rd();
	}
	
	void Toggle(){
		Debug.Log ("Toggle "+active);
		if (active) Enable3rd ();
		else Enable1st ();
	}
	
//TODO Move smoothly
	void Enable3rd(){
		active = false;
		camera.transform.localPosition = initialPosition + position3rd;
	}
	void Enable1st(){	
		active = true;
		camera.transform.localPosition = initialPosition;
	}
	
}
