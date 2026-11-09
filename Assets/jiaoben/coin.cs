using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 如果用 UI 显示分数

public class Coin : MonoBehaviour
{
    private bool collected = false;   // 防止重复收集

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;        // 已经收过了，直接返回
        if (!other.CompareTag("Player")) return;

        collected = true;             // 标记已收集
        GameManager.instance.AddCoin();
        Destroy(gameObject);
    }
}
