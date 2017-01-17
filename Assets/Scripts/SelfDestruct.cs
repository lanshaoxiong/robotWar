using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
	public float destructTime = 3.0f;

	public void Initiate(){
		Invoke ("selfDestruct", destructTime);
	}

	private void selfDestruct(){
		Destroy (gameObject);
	}
}
