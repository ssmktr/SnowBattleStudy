﻿using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

	public GameObject WeaponSocket;
	public GameObject SnowBall;

	private void attack()
	{
		Debug.Log ("ok");
		GameObject SnowBallObj = Instantiate (SnowBall,WeaponSocket.transform.position,Quaternion.identity) as GameObject;
	}
}