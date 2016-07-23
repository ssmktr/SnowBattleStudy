using UnityEngine;
using System.Collections;

public class FllowCam : MonoBehaviour {

    public Transform Target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 TempPos = new Vector3(Target.position.x, Target.position.y+2, Target.position.z-5);
        this.transform.position = TempPos;
        this.transform.LookAt(Target);

	}
}
