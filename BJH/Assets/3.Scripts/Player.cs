using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody Rigidbody;

	// Use this for initialization
	void Awake () {


        Rigidbody = this.GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.W))
        {

            Rigidbody.AddForce(new Vector3(0, 0, 100));

        }

	}
}
