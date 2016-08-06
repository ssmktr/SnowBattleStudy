using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

    public UIProgressBar ProgressBar;
    public Camera MainCamera, CharCamera;
    public GameObject MessageRoot;

    int CurHp = 10;
    int MaxHp = 10;
	void Start () {
        ProgressBar.value = (float)CurHp / MaxHp;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            MainCamera.gameObject.SetActive(true);
            CharCamera.gameObject.SetActive(false);
        }
        else
        {
            MainCamera.gameObject.SetActive(false);
            CharCamera.gameObject.SetActive(true);
        }
    }

    public void OnMessage(string _msg)
    {
        GameObject panel = (GameObject)Instantiate(Resources.Load("UI/HitMessage"));
        panel.transform.parent = MessageRoot.transform;
        panel.transform.localPosition = new Vector3(0, 250, 0);
        panel.transform.localScale = Vector3.one;

        panel.transform.FindChild("MsgLbl").GetComponent<UILabel>().text = _msg;

        Destroy(panel, 1f);
    }

    public void OnDamage()
    {
        CurHp--;
        ProgressBar.value = (float)CurHp / MaxHp;

        if (CurHp <= 0)
            Time.timeScale = 0.1f;
    }
}
