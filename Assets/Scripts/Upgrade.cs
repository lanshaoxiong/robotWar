using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	public Gun gun;
	void OnTriggerEnter(Collider other){
		gun.UpgradeGun ();
		Destroy (gameObject);
		SoundManager.Instance.PlayOneShot (SoundManager.Instance.powerUpPickup);
	}
}
