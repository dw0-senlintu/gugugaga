using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   // 场景管理

public class FinishPanelButtons : MonoBehaviour
{
    // 重玩：重新加载当前关卡
    public void OnReplay()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    // 回到主页：加载主菜单
    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // 下一关：加载下一个场景
    public void OnNextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);       // 还有下一关 → 加载
        else
            Debug.Log("已通关全部关卡！");        // 最后一关 → 提示
    }
}