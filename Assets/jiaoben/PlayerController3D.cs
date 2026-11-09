using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public bool isControlled = true;   // 新增：是否正在被玩家操控
    // ... 原有代码
    public static PlayerController3D instance;   // 单例
    public int coinCollected = 0;                 // 金币计数

    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    private void Awake()
    {
        instance = this;                          // 存单例
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void AddCoin()                         // 金币方法
    {
        coinCollected++;
        Debug.Log("吃到金币：" + coinCollected);
    }

    private void Update()
    {
        // 只有受控时才响应跳跃输入
        if (!isControlled) return;

        // 检测地面
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // 按空格跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        // 只有受控时才响应移动输入
        if (!isControlled) return;

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);
    }
}