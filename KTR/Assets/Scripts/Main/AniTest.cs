using UnityEngine;
using System.Collections;

public class AniTest : MonoBehaviour {
    public Animator Anim;
    public Rigidbody MyRigidbody;
    float h, v;

    void Start () {
        
    }

	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Anim.Play("Idle");
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Anim.Play("Walk_Forward");
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Anim.Play("Walk_Right");
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Anim.Play("Walk_Back");
        }
    }
}
