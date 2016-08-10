using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

		// How long the object should shake for.
		private float shake = 0f;
		// Amplitude of the shake. A larger value shakes the camera harder.
		public float shakeAmount = 0.7f;
		public float shakeTime = 0.5f;
		Vector3 originalPos;

		public void Shake() {
			originalPos = this.transform.localPosition;
			shake = shakeTime;
		}
		void Update() {
			if (shake > 0) {
				this.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
				shake -= Time.deltaTime;
				if (shake < 0) {
					shake = 0f;
					this.transform.localPosition = originalPos;
				}
			}
		}
}
