using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMgr : Singleton<GameMgr> {
    public SceneType SceneState = SceneType.Battle001;

    public static void GoScene(string SceneName)
    {
        GameMgr.Instance.SceneState = (SceneType)System.Enum.Parse(typeof(SceneType), SceneName);
        SceneManager.LoadScene(SceneName);
    }

}

public enum SceneType
{
    Main = 0,
    Battle001,
};