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

        Attack,
    };
    Dictionary<AniType, string> DicAnimation = new Dictionary<AniType, string>();

    public Battle Battle;
    public Animator Anim;
    bool bAttack = false;

    public GameObject SnowBullet, SnowFirePoint;

    void Start () {
        DicAnimation.Add(AniType.Idle, "Idle");
        DicAnimation.Add(AniType.Walk_Forward, "Walk_Forward");
        DicAnimation.Add(AniType.Walk_Back, "Walk_Back");
        DicAnimation.Add(AniType.Run_Forward, "Run_Forward");
        DicAnimation.Add(AniType.Run_Back, "Run_Back");
        DicAnimation.Add(AniType.Attack, "Attack");

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bAttack = true;
            SetAnimation(AniType.Attack);

            ThrowSnow();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            bAttack = false;
            SetAnimation(AniType.Idle);
        }

        if (!bAttack && transform.localPosition.y < 2)
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
                SetAnimation(AniType.Idle);
        }
        else
            SetAnimation(AniType.Idle);

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

    void ThrowSnow()
    {
        GameObject Snow = (GameObject)Instantiate(SnowBullet);
        Snow.transform.position = SnowFirePoint.transform.position;
        Snow.GetComponent<SnowBullet>().Fire(transform.forward, OnMessage);

        Destroy(Snow, 3f);
    }

    void OnMessage()
    {
        if (Battle != null)
        {
            Battle.OnMessage("HIT!!");
        }
    }
}

