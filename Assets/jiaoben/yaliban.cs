using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("可触发机关的门")]
    public MovingDoor targetDoor;      // 拖入要控制的门

    private int objectsOnPlate = 0;    // 记录板上压着几个物体（人和箱子都算）

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("压力板碰到：" + other.name + "，标签：" + other.tag);
        // 只对 角色(Player) 或 箱子(Box) 生效
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectsOnPlate++;
            UpdateDoor(); 
            // 有物体压上，更新门状态
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            objectsOnPlate--;
            UpdateDoor();              // 物体离开，更新门状态
        }
    }

    private void UpdateDoor()
    {
        // 板上还有物体 → 开门；没有 → 关门
        bool shouldOpen = objectsOnPlate > 0;
        targetDoor.SetOpen(shouldOpen);
    }
}
