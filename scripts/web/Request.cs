using UnityEngine;
using System.Collections;

public class Request : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string url = "http://javi-cv.herokuapp.com/json";

		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www) {
		yield return www;

		// check for errors
		if (www.error == null)	Debug.Log("WWW Ok!: " + www.data);
		else 	Debug.Log("WWW Error: "+ www.error);

		JSONObject json = new JSONObject(www.data);
		Debug.Log ("Personal name: " + json["personal-information"]["name"].str ) ;
	}
}
