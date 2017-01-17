using UnityEngine;
using System.Collections;

public class Arena : MonoBehaviour {

	public GameObject player;
	public Transform elevator;
	private Animator arenaAnimator;
	private SphereCollider sphereCollider;

	// Use this for initialization
	void Start () {
		arenaAnimator = GetComponent<Animator> ();
		sphereCollider = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Camera.main.transform.parent.gameObject.GetComponent<CameraMovement> ().enabled = false; // disable the camera movement
		player.transform.parent = elevator.transform; // make the marine the child of platform 
		player.GetComponent<PlayerController>().enabled = false;
		SoundManager.Instance.PlayOneShot (SoundManager.Instance.elevatorArrived);
		arenaAnimator.SetBool ("OnElevator", true);
	}

	public void ActivatePlatform(){
		sphereCollider.enabled = true;
	}
}
