using UnityEngine;
using System.Collections;

public class FllowCam : MonoBehaviour {

    public Transform Target;

	public float minX = -90.0f;
	public float maxX = 90.0f;

	public float minY = -10.0f;
	public float maxY = 10.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;
	public float sensZ = 50.0f;


	float rotationY = 0.0f;
	float rotationX = 0.0f;

	float posZ = 0;

	// Use this for initialization
	void Start () {
		posZ = - 5.0f;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 TempPos = new Vector3(Target.position.x, Target.position.y+2, Target.position.z + posZ);
        this.transform.position = TempPos;
        this.transform.LookAt(Target);

		posZ += Input.GetAxis ("Mouse ScrollWheel") * sensZ * Time.deltaTime;
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		//transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

		transform.RotateAround (Target.position, Vector3.up, rotationX);
		transform.RotateAround (Target.position, Vector3.right, -rotationY);
	}
}
