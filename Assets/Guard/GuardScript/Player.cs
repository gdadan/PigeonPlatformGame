using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;     // �÷��̾� �̵� �ӵ�
    [SerializeField] float jumpPower = 5f;       // �÷��̾� ���� ����

    Rigidbody2D rigid;      // �÷��̾� RigidBody

    int jumpCount;          // ���� Ƚ��
    int jumpCountMax = 2;   // �ִ� ���� Ƚ��

    bool isGround = true;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpCount = jumpCountMax;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    // �÷��̾� ������
    void Move()
    {
        float moveAxisX = Input.GetAxis("Horizontal");

        Vector3 moveVec = new Vector3(moveAxisX, 0, 0);

        transform.position += moveVec * playerSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            Debug.Log("jump");
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    void Gliding()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isGround)
        { 

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            jumpCount = jumpCountMax;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
