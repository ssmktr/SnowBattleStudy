using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

    public GameObject MessageRoot;
	void Start () {
	    
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
}
