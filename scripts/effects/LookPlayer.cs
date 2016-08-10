using UnityEngine;
using System.Collections;

public class LookPlayer : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null)this.transform.LookAt(player.transform.position);
	}
}
