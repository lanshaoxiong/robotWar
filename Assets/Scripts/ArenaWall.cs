using UnityEngine;
using System.Collections;

public class ArenaWall : MonoBehaviour {
	private Animator arenaAnimator;

	// Use this for initialization
	void Start () {
		GameObject arena = transform.parent.gameObject;
		arenaAnimator = arena.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		arenaAnimator.SetBool ("IsLowered",true);
	}

	void OnTriggerExit(Collider other){
		arenaAnimator.SetBool ("IsLowered", false);
	}
}
