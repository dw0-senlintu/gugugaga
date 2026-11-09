using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleIconUI : MonoBehaviour
{
    public PlayerSwitcher switcher;       // 拖入 PlayerSwitcher

    public Image icon1;                   // 第 1 个头像
    public Image icon2;                   // 第 2 个头像

    // 高亮 / 变暗的颜色
    public Color activeColor = Color.white;                        // 当前操控：亮
    public Color inactiveColor = new Color(0.45f, 0.45f, 0.45f);      // 非操控：暗

    private void Update()
    {
        if (switcher == null) return;

        bool isFirst = (switcher.CurrentIndex == 0);   // 是否操控第 1 个

        icon1.color = isFirst ? activeColor : inactiveColor;
        icon2.color = isFirst ? inactiveColor : activeColor;
    }
}