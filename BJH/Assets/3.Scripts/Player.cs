using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody Rigidbody;
	private Animator anim;

	// Use this for initialization
	void Awake () {


        Rigidbody = this.GetComponent<Rigidbody>();
		anim = this.transform.FindChild("Robot Kyle").GetComponent<Animator> ();

    }
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey(KeyCode.W))
        {

            //Rigidbody.AddForce(new Vector3(0, 0, 100));
			Rigidbody.velocity = new Vector3(0,0,5);

			 

        }

		if (Input.GetKey(KeyCode.S))
		{

			//Rigidbody.AddForce(new Vector3(0, 0, 100));
			Rigidbody.velocity = new Vector3(0,0,-5);

		}

		if (Input.GetKey(KeyCode.A))
		{

			//Rigidbody.AddForce(new Vector3(0, 0, 100));
			Rigidbody.velocity = new Vector3(5,0,0);

		}

		if (Input.GetKey(KeyCode.D))
		{

			//Rigidbody.AddForce(new Vector3(0, 0, 100));
			Rigidbody.velocity = new Vector3(-5,0,0);

		}
	}
}
