using UnityEngine;
using System.Collections;

public class teddySc : monsterSc {

	private bool OnceCo_Enter = false;


	// Use this for initialization
	void Awake () {
		MonState = MONSTATE.IDLE;
	}

	void Update(){
		StateFunc ();
	}


	public void StateFunc()
	{
		switch (MonState) {
		case MONSTATE.IDLE:
			StartCoroutine("idleFunc");
			OnceCo_Enter = false;
			break;

		case MONSTATE.MOVE:
			StartCoroutine("moveFunc");
			OnceCo_Enter = false;
			break;

		case MONSTATE.ATTACK:
			StartCoroutine("attackFunc");
			OnceCo_Enter = false;
			break;

		case MONSTATE.DIED:
			StartCoroutine("diedFunc");
			OnceCo_Enter = false;
			break;

		}
	}



	public override IEnumerator idleFunc ()
	{
		OnceCo_Enter = true;
		yield return new WaitForSeconds(1f);
		Debug.Log("idle");
	}

	public override IEnumerator moveFunc ()
	{
		OnceCo_Enter = true;
		yield return new WaitForSeconds(1f);
		Debug.Log("move");
	}

	public override IEnumerator attackFunc ()
	{
		OnceCo_Enter = true;
		yield return new WaitForSeconds(1f);
		Debug.Log("attack");
	}

	public override IEnumerator diedFunc ()
	{
		OnceCo_Enter = true;
		yield return new WaitForSeconds(1f);
		Debug.Log("died");
	}
}
