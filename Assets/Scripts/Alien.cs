using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Alien : MonoBehaviour {
	public Transform target;
	private UnityEngine.AI.NavMeshAgent agent;

	public float navigationUpdate;
	private float navigationTime = 0; 

	public Rigidbody head;
	public bool isAlive = true;


	public UnityEvent OnDestroy;

	private DeathParticles deathParticles;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		navigationTime += Time.deltaTime;
		if (navigationTime > navigationUpdate) {
			if (target != null) {
				agent.destination = target.position;
			}
			navigationTime = 0;
		}
	}

	void OnTriggerEnter(Collider other){
//		Destroy (gameObject);
		if (isAlive) {
			Die ();
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.alienDeath);
		}
	}

	public void Die(){
		isAlive = false;
		head.GetComponent<Animator> ().enabled = false;
		head.isKinematic = false;
		head.useGravity = true;
		head.GetComponent<SphereCollider> ().enabled = true;
		head.gameObject.transform.parent = null;
		head.velocity = new Vector3 (0, 26.0f, 3.0f);


		OnDestroy.Invoke ();
		OnDestroy.RemoveAllListeners ();
		SoundManager.Instance.PlayOneShot (SoundManager.Instance.alienDeath);

		head.GetComponent<SelfDestruct> ().Initiate ();

		if (deathParticles) {
			deathParticles.transform.parent = null;
			deathParticles.Activate ();
		}
		Destroy (gameObject);
	}

	public DeathParticles GetDeathParticles(){
		if (deathParticles == null) {
			deathParticles = GetComponentInChildren<DeathParticles> ();
		}
		return deathParticles;
	}
}
