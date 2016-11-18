using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody MyRigidbody;
    private Animator Anim;
    public float Speed;  // 움직이는 스피드.
    private float h = 0.0f;
    private float v = 0.0f;




	// Use this for initialization
	void Awake () {


        MyRigidbody = this.GetComponent<Rigidbody>();
        Anim = this.transform.FindChild("Robot Kyle").GetComponent<Animator>();
      
    }
	
    private float AnimSpeed = 0;
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Horizontal");// 이값은  메뉴창에 Editor -> Project Settings -> Input에 Horizontal에서 얻어오는건데. 자주쓰는 키조합을 미리 정의해 놓은것이다.
        v = Input.GetAxis("Vertical");  // 이 두값은  꾹 누르고 있으면 -1~ 1 까지의 값으로 이루어 져있다.
                                        // h 는  A 키 와 D 키  (-1~1)
                                        // V 는 W 키와 S키   (-1~1)
                                        //Debug.Log("H" + h);
                                        //Debug.Log("V" + v);


        //현재 Speed * h 값은 하게 된다면 만약 speed가 10이고 h값이 0 이라면  x값은 0이되고 , h값이 0.5면 그에 반값인 5, h값이 1이면 10의 값이 되므면 위에 키값에 따라 달라진다. 
        //가운데 MyRigibody.velocity.y를 준것은 별 의미 없고 자기의 현재 y으로 떨어지거나 증가하는 물리값이다. 이걸 그냥 0 으로 둔다면  이 물체는  떨어지거나 올라가지못하고  y축으로 고정된다.
        MyRigidbody.velocity = new Vector3(h* Speed, MyRigidbody.velocity.y, v* Speed);
        Anim.SetFloat("YSpeed", -h);  // 실수로 애니메이션 값을 반대로 만들어서 - 해 버렸다. 
        Anim.SetFloat("XSpeed", v);

        if (Input.GetMouseButtonDown(0))
        {
            Anim.SetTrigger("Attack");
			Debug.Log ("Attack");
        }


    }


}
