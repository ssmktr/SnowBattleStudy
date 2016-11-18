using UnityEngine;
using System.Collections;

public class SnowBallSc : MonoBehaviour {

	public GameObject EffectPrefab;

	private Rigidbody MyRigidbody;

	// Use this for initialization
	void Awake () {
		MyRigidbody = this.transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		MyRigidbody.velocity = new Vector3 (MyRigidbody.velocity.x, MyRigidbody.velocity.y, 50.0f);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision.gameObject.name);

		GameObject EffectObj = Instantiate (EffectPrefab, this.transform.position, Quaternion.identity) as GameObject;
		Destroy (this.gameObject);
	}
}
