using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    // 两个角色（拖进来）
    public PlayerController3D[] players;

    private int currentIndex = 0;   // 当前操控第几个（0=第1个，1=第2个）
    // 新增：对外暴露"当前操控第几个"，供 UI 读取
    public int CurrentIndex { get { return currentIndex; } }

    private void Start()
    {
        SetControl(0);   // 开局默认操控第 1 个
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetControl(0);   // 按 1 → 操控第 1 个
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetControl(1);   // 按 2 → 操控第 2 个
    }

    // 切换操控对象
    private void SetControl(int index)
    {
        if (index < 0 || index >= players.Length) return;
        if (currentIndex == index) return;   // 已经在控制他了，不重复

        for (int i = 0; i < players.Length; i++)
        {
            players[i].isControlled = (i == index);   // 只有被选中的受控
        }

        currentIndex = index;
        Debug.Log("现在操控第 " + (index + 1) + " 个角色");
    }
}
