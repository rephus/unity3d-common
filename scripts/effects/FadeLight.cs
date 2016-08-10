using UnityEngine;
using System.Collections;

public class FadeLight : MonoBehaviour {

	public float fadeSpeed = 20;

	private Light light;
	private int maxIntensity = 5;
	private int minIntensity = 1;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		light.range += Time.deltaTime * fadeSpeed ;
		if (light.range >= maxIntensity || light.range <= minIntensity) fadeSpeed = -fadeSpeed;
	}
}
