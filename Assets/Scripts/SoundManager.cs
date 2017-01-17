using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance = null;
	private AudioSource soundEffectAudio;

	public AudioClip gunFire;
	public AudioClip upgradeGunFire;
	public AudioClip hurt;
	public AudioClip alienDeath;
	public AudioClip marineDeath;
	public AudioClip victory;
	public AudioClip elevatorArrived;
	public AudioClip powerUpPickup;
	public AudioClip powerUpAppear;

	// Use this for initialization
	void Start () {

		// Singleton design pattern: there is always only one copy of this object in existence
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		AudioSource[] sources = GetComponents<AudioSource> (); // return all of the components of a particular type
		foreach (AudioSource source in sources) {
			// the first Audio Source
			if(source.clip == null){
				soundEffectAudio = source;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayOneShot(AudioClip clip){
		soundEffectAudio.PlayOneShot (clip);
	}
}
