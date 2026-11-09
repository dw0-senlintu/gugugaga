using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;          // 使用 TextMeshPro（你用的是 TMP）

public class CoinHUD : MonoBehaviour
{
    public TMP_Text coinText;    // 拖入显示数字的 TMP 文字
    public int totalCoins = 3;   // 金币总数（对应关卡里金币数量）

    private void Update()
    {
        // 每帧从 GameManager 读取已收集数量，刷新显示
        if (GameManager.instance != null && coinText != null)
        {
            coinText.text = GameManager.instance.collectedCoins + " / " + totalCoins;
        }
    }
}