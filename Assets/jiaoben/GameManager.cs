using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalCoins = 3;      // 关卡金币总数（可手动填）
    public int collectedCoins = 0;  // 已收集金币
    public bool levelFinished = false;
    public GameObject finishPanel;// 新增：拖入 FinishPanel。关面板（默认隐藏的）挂在这里
    private void Awake()
    {
        instance = this;
    }

    // 收集金币时调用
    public void AddCoin()
    {
        collectedCoins++;
        Debug.Log("金币：" + collectedCoins);
    }

    // 到达终点时调用
    public void FinishLevel()
    {
        if (levelFinished) return;   // 防止重复触发
        levelFinished = true;

        Debug.Log("过关！收集金币：" + collectedCoins + "/" + totalCoins);
        // 这里后面接 UI 显示

        // 新增：把过关面板显示出来
        if (finishPanel != null)
            finishPanel.SetActive(true);
        // 新增：延迟 2 秒后切到下一关
        //Invoke("LoadNextLevel", 2f);
    }

    // 新增一个方法：加载下一关
    private void LoadNextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);      // 还有下一关 → 加载
        else
            Debug.Log("已通关全部关卡！");      // 没有 → 提示通关
    }
}

