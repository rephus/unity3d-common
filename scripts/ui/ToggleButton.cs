using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour {
	
	public GameObject gameObject;
	public bool active;

	// Use this for initialization
	void Start () {

		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { Toggle(); });

		active = !active;
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
