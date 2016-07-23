using UnityEngine;
using System.Collections;

public class GameMgr : Singleton<GameMgr> {

    public int Level = 0;

    public void Test(int num)
    {
        Debug.Log(num);
    }
}
