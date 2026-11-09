using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    public RectTransform content;        // 滑动容器
    public float step = 320f;            // 按一次 A/D 滑动多少（≈图标宽度+间距）
    public float smooth = 8f;            // 平滑度，越大越快
    public float minX = 0f;              // 最左能滑到哪
    public float maxX = -1280f;          // 最右能滑到哪（按内容总宽算，填负数）

    private float targetX;
    private float cooldown = 0.2f;
    private float timer = 0f;

    private void Start()
    {
        targetX = content.anchoredPosition.x;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            float h = Input.GetAxisRaw("Horizontal");

            if (h < -0.5f)        // A / 左：内容往右滑
            {
                targetX += step;
                timer = cooldown;
            }
            else if (h > 0.5f)    // D / 右：内容往左滑
            {
                targetX -= step;
                timer = cooldown;
            }

            targetX = Mathf.Clamp(targetX, maxX, minX);   // 限制范围
        }

        // 平滑滑动
        Vector2 pos = content.anchoredPosition;
        pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * smooth);
        content.anchoredPosition = pos;
    }
}