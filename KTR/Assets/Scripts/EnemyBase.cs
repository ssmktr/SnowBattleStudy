using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public GameObject SnowBullet;
    public Transform Target, SnowFirePoint;
    public Animator Anim;
    public Battle Battle;

    float AttackTime = 0.0f;
    float AttackRangeTime = 2.0f;

    void Start () {
        Anim.Play("Idle");
    }
	
	void Update () {
        if (Vector3.Distance(Target.localPosition, transform.localPosition) < 10)
        {
            transform.LookAt(Target);

            if (AttackTime >= AttackRangeTime)
            {
                Anim.Play("Attack");
                Fire();
                AttackTime = 0f;
            }
            else
            {
                Anim.Play("Walk_Forward");
                transform.Translate(Vector3.forward * Time.deltaTime * 3f);
            }
        }
        else
            Anim.Play("Idle");
        AttackTime += Time.deltaTime;
	}

    void Fire()
    {
        GameObject Snow = (GameObject)Instantiate(SnowBullet);
        Snow.transform.position = SnowFirePoint.position;
        Snow.GetComponent<SnowBullet>().Fire(transform.forward, OnMessage);

        Destroy(Snow, 3f);
    }

    void OnMessage()
    {
        if (Battle != null)
        {
            Battle.OnDamage();
            Battle.OnMessage("Damaged...");
        }
    }
}
