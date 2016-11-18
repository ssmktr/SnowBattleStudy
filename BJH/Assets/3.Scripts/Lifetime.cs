using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
		StartCoroutine ("DelayTime");
	}
	
	IEnumerator DelayTime(){
		yield return new WaitForSeconds (1.0f);
		Destroy (this.gameObject);
	}
}
