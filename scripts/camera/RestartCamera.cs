using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestartCamera : MonoBehaviour {
	
	public CameraGyroController cameraGyro;
	public Vector3 rotationBase;
	public GameObject lookTo;

	// Use this for initialization
	void Start () {
		
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(delegate() { OnClick(); });
	}
	
	void OnClick(){
		//cameraGyro.ResetGyro();
		//cameraGyro.referanceRotation = Quaternion.LookRotation(lookTo.transform.position);
	}//

	
}
