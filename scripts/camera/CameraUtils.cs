using UnityEngine;
using System.Collections;

public class CameraUtils : MonoBehaviour {

	//Viewport mode
	/*Vector3 position = Camera.main.WorldToViewportPoint(this.transform.position);
		bool newVisible = position.x > 0 && position.y > 0;
		*/

	//Renderer visible
	/*bool rendererVisible = this.gameObject.renderer.isVisible;
		Debug.Log ("Renderer visible " +this.transform.parent.name +" " + rendererVisible);
		return rendererVisible;*/

	//Frustum
	/*Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
	Bounds bounds = new Bounds(this.transform.position, new Vector3(1,1,1));
	return GeometryUtility.TestPlanesAABB(planes, bounds);
	*/

	//Camera angle mode (not finished)
	/*Quaternion rotation = Quaternion.LookRotation(this.transform.position);
		Debug.Log ("Rotation with " +this.transform.parent.name +" " + rotation);
		return false;*/
	static public bool IsVisible(Vector3 v){
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		Bounds bounds = new Bounds(v, new Vector3(1,1,1));
		return GeometryUtility.TestPlanesAABB(planes, bounds);
	}

	static public GameObject Raycast(Vector3 position, Vector3 forward) {

		Debug.DrawRay(position,forward);
		RaycastHit hit;
		if (Physics.Raycast(position, forward, out hit ) ) {
			Debug.Log("Hit " + hit + " name " + hit.collider.gameObject.name);
			return hit.transform.gameObject;
		} else return null;
	}
}
