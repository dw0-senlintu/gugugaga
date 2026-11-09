using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;              // TMP 文字

public class FinishPanelUI : MonoBehaviour
{
    public TMP_Text coinText;     // 显示"收集金币 X / 3"的文字
    public int totalCoins = 3;

    void OnEnable()               // 面板被显示的那一刻自动执行
    {
        if (GameManager.instance != null)
        {
            int c = GameManager.instance.collectedCoins;
            coinText.text = "收集金币 " + c + " / " + totalCoins;

            // 简单星级规则：全收3星，收2个2星，其余1星
            int stars = (c >= totalCoins) ? 3 : (c >= 2 ? 2 : 1);
            Debug.Log("获得星级：" + stars);
        }
    }
}