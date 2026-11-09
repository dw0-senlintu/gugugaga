using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour          
{
    [Header("移动设置")]
    public Transform openPoint;                  
    public float moveSpeed = 2f;                 

    private Vector3 closedPos;
    private Vector3 targetPos;
    //private void Start()
    //{
       // SetOpen(true);   // 测试用：进游戏就让门打开
   // }
    private void Awake()
    {
        closedPos = transform.position;
        targetPos = closedPos;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime        
        );
    }

    public void SetOpen(bool open)            
    {
        targetPos = open ? openPoint.position : closedPos;
    }
}