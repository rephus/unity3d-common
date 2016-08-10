// ***********************************************************
// Written by Heyworks Unity Studio http://unity.heyworks.com/
// ***********************************************************
using UnityEngine;

/// <summary>
/// Gyroscope controller that works with any device orientation.
/// </summary>
public class CameraGyroController : MonoBehaviour 
{
	private bool gyroEnabled = true;
	private const float lowPassFilterFactor = 0.2f;

	private readonly Quaternion baseIdentity =  Quaternion.Euler(90, 0, 0);
	
	public Quaternion cameraBase =  Quaternion.identity;
	private Quaternion calibration =  Quaternion.identity;
	private Quaternion baseOrientation =  Quaternion.Euler(90, 0, 0);
	private Quaternion baseOrientationRotationFix =  Quaternion.identity;

	private Quaternion referanceRotation = Quaternion.identity;
	private bool debug = false;

	protected void Start () {

		/*if(Application.platform == RuntimePlatform.Android) ;
		else if(Application.platform == RuntimePlatform.IPhonePlayer) ; 
		else this.enabled = false;*/

		if (enabled) {
			Debug.Log ("Device "+Application.platform +" supports gyro");
			AttachGyro();

			Input.gyro.enabled = true;
		}

		LookTo(new Vector3(0,5.1f, 20.8f));
		

	}

	protected void Update() 
	{
		if (!gyroEnabled) return;
		Quaternion newRotation = ConvertRotation(referanceRotation * Input.gyro.attitude) * GetRotFix();
		transform.localRotation = Quaternion.Slerp(transform.localRotation, cameraBase  * newRotation , lowPassFilterFactor);
	}

	protected void OnGUI()
	{
		if (!debug) return;

		GUILayout.Label("Orientation: " + Screen.orientation);
		GUILayout.Label("Calibration: " + calibration);
		//GUILayout.Label("Camera base: " + pivot.transform.rotation);
		GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
		GUILayout.Label("transform.rotation: " + transform.rotation);

	}

	public void LookTo(Vector3 vector){
		Debug.Log("Loooking into " + vector);
		cameraBase = Quaternion.LookRotation( vector);
		//transform.LookAt(vector);// Quaternion.LookRotation(vector) ;
		ResetGyro ();
	}
	public void ResetGyro(){
		referanceRotation = Quaternion.Inverse(Input.gyro.attitude);
	}

	private void AttachGyro()
	{
		
		gyroEnabled = true;
		ResetBaseOrientation();
		UpdateCalibration(true);
		//UpdateCameraBaseRotation(true);
		RecalculateReferenceRotation();
	}

	private void DetachGyro() {
		gyroEnabled = false;
	}

	private void UpdateCalibration(bool onlyHorizontal) {
		if (onlyHorizontal) {
			var fw = (Input.gyro.attitude) * (-Vector3.forward);
			fw.z = 0;
			if (fw == Vector3.zero) calibration = Quaternion.identity;
			else calibration = (Quaternion.FromToRotation(baseOrientationRotationFix * Vector3.up, fw));
		}
		else calibration = Input.gyro.attitude;
	}
	
	public void UpdateCameraBaseRotation(bool onlyHorizontal) {
		if (onlyHorizontal) {
			var fw = transform.forward;
			fw.y = 0;
			if (fw == Vector3.zero) cameraBase = Quaternion.identity;
			else cameraBase = Quaternion.FromToRotation(Vector3.forward, fw);
 		}
		else cameraBase = transform.rotation;
	}
	
	private static Quaternion ConvertRotation(Quaternion q) {
		return new Quaternion(q.x, q.y, -q.z, -q.w);	
	}
	
	private Quaternion GetRotFix() {
		return Quaternion.identity;
	}
	
	public void ResetBaseOrientation()
	{
		baseOrientationRotationFix = GetRotFix();
		baseOrientation = baseOrientationRotationFix * baseIdentity;
	}

	private void RecalculateReferenceRotation() {
		referanceRotation = Quaternion.Inverse(baseOrientation)*Quaternion.Inverse(calibration);
	}
}
