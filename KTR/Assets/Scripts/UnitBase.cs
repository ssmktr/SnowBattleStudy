using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitBase : MonoBehaviour {

    public enum AniType
    {
        Idle = 0,

        Walk_Forward,
        Walk_Back,

        Run_Forward,
        Run_Back,
    };

    public Animator Anim;

    Dictionary<AniType, string> DicAnimation = new Dictionary<AniType, string>();

	void Start () {
        DicAnimation.Add(AniType.Idle, "Idle");
        DicAnimation.Add(AniType.Walk_Forward, "Walk_Forward");
        DicAnimation.Add(AniType.Walk_Back, "Walk_Back");
        DicAnimation.Add(AniType.Run_Forward, "Run_Forward");
        DicAnimation.Add(AniType.Run_Back, "Run_Back");

        Anim.speed = 3f;
    }

    void Update()
    {
        ControlAnimation();
    }

    public virtual void SetAnimation(AniType eType)
    {
        if (Anim != null)
            Anim.Play(DicAnimation[eType]);
    }

    public virtual void ControlAnimation()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            SetAnimation(AniType.Run_Forward);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            SetAnimation(AniType.Run_Back);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            SetAnimation(AniType.Walk_Forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetAnimation(AniType.Walk_Back);
        }
        else
        {
            SetAnimation(AniType.Idle);
        }

        float v = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * v * Time.deltaTime * 120);
    }

    void OnTriggerEnter(Collider coll)
    {
        switch (coll.name)
        {
            case "Battle001Gate":
                GameMgr.GoScene("Battle001");
                break;

            case "MainGate":
                GameMgr.GoScene("Main");
                break;
        };
    }
}
