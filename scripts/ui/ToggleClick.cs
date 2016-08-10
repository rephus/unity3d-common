using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleClick : MonoBehaviour {
	
	public GameObject gameObject;
	public bool active = true;

	// Use this for initialization
	void Start () {
		active = !active;
		Toggle ();
	}

	void OnMouseDown()  {
		Toggle ();
	}

	void Toggle(){
		if (active) DisableObject ();
		else EnableObject ();
	}

	void DisableObject(){
		active = false;
		gameObject.SetActive (active);
	}
	void EnableObject(){	
		active = true;
		gameObject.SetActive (active);
	}
}
