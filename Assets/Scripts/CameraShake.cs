using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

  public float shakeDecay = 0.002f; // the time of shake 
  public float intensity = .3f; // the intensity of shake

  private Vector3 originPosition;
  private Quaternion originRotation;
  private float shakeIntensity = 0;

  void Update() {
    if (shakeIntensity > 0) {
      transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
      transform.rotation = new Quaternion(
      originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
      originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
      originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
      originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .2f);
      shakeIntensity -= shakeDecay;
    }
  }

  public void Shake() {
    originPosition = transform.position;
    originRotation = transform.rotation;
    shakeIntensity = intensity;
  }
}
