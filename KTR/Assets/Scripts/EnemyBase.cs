using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour {

    public GameObject SnowBullet;
    public Transform Target, SnowFirePoint;
    public Animator Anim;
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
        }
        AttackTime += Time.deltaTime;
	}

    void Fire()
    {
        GameObject Snow = (GameObject)Instantiate(SnowBullet);
        Snow.transform.position = SnowFirePoint.position;
        Snow.GetComponent<SnowBullet>().Fire(transform.forward);

        Destroy(Snow, 3f);
    }
}
