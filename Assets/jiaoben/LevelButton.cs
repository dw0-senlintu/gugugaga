using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string sceneName;   // 这个图标对应哪个关卡

    // 按钮点击时调用
    public void OnClickLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}