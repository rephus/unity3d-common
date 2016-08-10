using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public int seconds = 10;

	//Might want to call Invoke("Destroy", 0, seconds/1000) instead
	void Update () {
		if (time > seconds) Destroy (this.gameObject);
	}
}
