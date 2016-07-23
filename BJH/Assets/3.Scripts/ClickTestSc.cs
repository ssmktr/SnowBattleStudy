using UnityEngine;
using System.Collections;

public class ClickTestSc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public Ray ray;
    public RaycastHit hitInfo;
    // Update is called once per frame
    void Update () {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("dsada");
            if (Physics.Raycast(ray, out hitInfo))
            {
               
                //Debug.Log("hitInfo"+ hitInfo.transform.gameObject.name);
              //Debug.Log(hitInfo.transform.gameObject.GetComponent<Mesh>().vertices[].x; //gameObject name
            }
        }


    }
}
