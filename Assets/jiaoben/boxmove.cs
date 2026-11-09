using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PushableBox : MonoBehaviour
{
    // 推箱子的核心：当角色从某方向撞到箱子，箱子往同方向移动
    // 需要箱子上挂 Rigidbody（作为运动学移动）和 BoxCollider（用于碰撞检测）

    [Header("推动方向检测")]
    public LayerMask wallLayer;      // 墙,障碍物的层，用来判断前方有没有挡路
    public float pushCheckDistance = 1.0f; // 检测前方是否被挡的距离（约一个格子宽度）

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // 这个方法会在"角色碰到这个箱子"时自动被调用
        // hit 里带有角色推动的方向等信息
        TryPush(hit.moveDirection);
    }

    private void TryPush(Vector3 pushDir)
    {
        // 把推动方向压平到水平面（去掉上下）
        pushDir.y = 0f;
        pushDir.Normalize();

        // 检测箱子前方（要推动的方向）有没有墙/其他障碍
        if (Physics.Raycast(transform.position, pushDir, out RaycastHit hit, pushCheckDistance, wallLayer))
        {
            // 前方被挡住了 → 推不动，直接返回
            return;
        }

        // 前方没挡住 → 箱子移动一个格子（沿推动方向）
        transform.position += pushDir;  // 这里按一个单位移动，可按需改成 moveStep
    }
}
