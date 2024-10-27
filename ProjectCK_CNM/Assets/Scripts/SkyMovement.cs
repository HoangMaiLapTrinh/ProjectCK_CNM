using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    public enum StartDirection { Left, Right } // Định nghĩa lựa chọn hướng di chuyển
    public StartDirection startDirection = StartDirection.Right; // Hướng di chuyển ban đầu

    public float moveDistance = 5.0f;  // Khoảng cách di chuyển
    public float speed = 2.0f;         // Tốc độ di chuyển

    private Vector3 startPosition;
    private bool movingRight;

    void Start()
    {
        // Lưu vị trí bắt đầu của sky
        startPosition = transform.position;

        // Xác định hướng di chuyển ban đầu dựa trên lựa chọn của người dùng
        if (startDirection == StartDirection.Right)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }
    }

    void Update()
    {
        // Tính toán hướng di chuyển
        float moveDirection = movingRight ? 1 : -1;

        // Di chuyển object theo hướng và tốc độ
        transform.Translate(Vector3.right * moveDirection * speed * Time.deltaTime);

        // Kiểm tra nếu đã di chuyển hết khoảng cách cho phép
        if (movingRight && transform.position.x >= startPosition.x + moveDistance)
        {
            movingRight = false;  // Đổi hướng di chuyển sang trái
        }
        else if (!movingRight && transform.position.x <= startPosition.x - moveDistance)
        {
            movingRight = true;   // Đổi hướng di chuyển sang phải
        }
    }
}

