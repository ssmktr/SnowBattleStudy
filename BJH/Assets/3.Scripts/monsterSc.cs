using UnityEngine;
using System.Collections;

public class monsterSc : MonoBehaviour {
	public float hp;
	public float moveSpeed;
	public float attackSpeed;
	public MONSTATE MonState;

	public enum MONSTATE
	{
		IDLE,
		MOVE,
		ATTACK,
		DIED

	}
		


	public virtual IEnumerator idleFunc(){
		Debug.Log ("idle");
		yield return null;
	}

	public virtual IEnumerator moveFunc(){
		Debug.Log ("move");
		yield return null;
	}

	public virtual IEnumerator attackFunc(){
		Debug.Log ("attack");
		yield return null;
	}

	public virtual IEnumerator diedFunc(){
		Debug.Log ("died");
		yield return null;
	}

}
