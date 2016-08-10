using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { OnClick(); });
	}

	//override this method on class
	public void OnClick(){}
}
