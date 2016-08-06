using UnityEngine;
using System.Collections;

public class SnowBullet : MonoBehaviour {

    float SnowBulletSpeed = 800f;
    System.Action HitCallBack;

    public void Fire (Vector3 dir, System.Action _hitCallBack = null)
    {
        GetComponent<Rigidbody>().AddForce(dir * SnowBulletSpeed);
        HitCallBack = _hitCallBack;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (HitCallBack != null)
            {
                HitCallBack();
            }

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        else if (coll.tag == "Player")
        {
            if (HitCallBack != null)
            {
                HitCallBack();
            }

            Destroy(gameObject);
        }
    }
}
