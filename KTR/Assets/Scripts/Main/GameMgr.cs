using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMgr : Singleton<GameMgr> {

    public static void GoScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
