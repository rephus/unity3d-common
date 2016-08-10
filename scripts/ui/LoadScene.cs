using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	public int enemies;
	// Use this for initialization
	void Start () {
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { Load(); });
	}

	void Load(){
		StaticScene.enemies = enemies;
		Application.LoadLevel ("space");
	}


}
