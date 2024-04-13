using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    [SerializeField] float playerSpeed = 3f;             // �÷��̾� �̵� �ӵ�
    [SerializeField] float jumpPower = 8f;               // �÷��̾� ���� ����
    [SerializeField] float gliderGravity = 0.1f;         // �÷��̾� ���� ����

    Rigidbody2D rigid;      // �÷��̾� RigidBody
    Animator anim;          // �÷��̾� Animatior
    SpriteRenderer spriterenderer;
    AudioSource audiosource;

    int jumpCount;          // ���� Ƚ��
    int jumpCountMax = 2;   // �ִ� ���� Ƚ��

    bool isGround = true;       // ���� ��� �ִ��� Ȯ��(����, Ȱ�� �� false)
    bool canGlide = true;       // Ȱ���� �� �� �ִ��� Ȯ��(Ȱ���� ���߿� ���� �� �� �� ����)
    bool isConfused = false;    // �������� �¾� ȥ���������� Ȯ��
    bool isRight = true;        // �������� �ٶ�

    public AudioClip walkSource, jumpSource;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();                            // �÷��̾� RigidBody
        anim = GetComponent<Animator>();                                // �÷��̾� Animator
        spriterenderer = GetComponent<SpriteRenderer>();                // �÷��̾� SpriteRenderer
        audiosource = GetComponent<AudioSource>();

        jumpCount = jumpCountMax;           // ���� Ƚ���� �ִ� ���� Ƚ���� �ʱ�ȭ
        rigid.gravityScale = 2f;            // �⺻ �߷� ũ�⸦ 2��� ��
    }

    private void Update()
    {
        if (isConfused) return;
        Move();
        Jump();
        Gliding();
    }

    // �÷��̾� ������
    void Move()
    {
        float moveAxisX = Input.GetAxis("Horizontal");

        // �������� �̵��� �� ������ �ٶ�
        // ���������� �̵��� �� �������� �ٶ�
        if (moveAxisX < 0 && isRight) isRight = false;
        else if (moveAxisX > 0 && !isRight) isRight = true;

        if (isRight) spriterenderer.flipX = false;
        else spriterenderer.flipX = true;

        // ������ ���� �� �̵� �ִϸ��̼� false
        if (moveAxisX == 0) anim.SetBool("isMove", false);
        // ������ �� �̵� �ִϸ��̼� true
        else
        {
            if (!audiosource.isPlaying && isGround)
            {
                audiosource.clip = walkSource;
                audiosource.Play();
            }
            
            anim.SetBool("isMove", true);
        }

        Vector3 moveVec = new Vector3(moveAxisX, 0, 0);

        transform.position += moveVec * playerSpeed * Time.deltaTime;
    }

    // �÷��̾� ����
    void Jump()
    {
        // XŰ�� ������ �� ���� Ƚ���� �����ִٸ� ����
        if (Input.GetKeyDown(KeyCode.X) && jumpCount > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            // ���� Ƚ�� 1ȸ ����
            jumpCount--;

            audiosource.clip = jumpSource;
            audiosource.Play();
        }
    }

    // �÷��̾� Ȱ��
    void Gliding()
    {
        // ZŰ�� ������ Ȱ�� ����(�����ϴ� ���� ����)
        if (Input.GetKeyDown(KeyCode.Z) && canGlide) rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // ZŰ�� ��� ������ ������ Ȱ��(�߷� ũ�⸦ ����)
        else if (Input.GetKey(KeyCode.Z) && !isGround && canGlide)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.clip = jumpSource;
                audiosource.Play();
            }
            rigid.gravityScale = gliderGravity;
        }
        // ZŰ�� ���� Ȱ�� �Ұ��� ���·� ����
        else if (Input.GetKeyUp(KeyCode.Z)) canGlide = false;
        // Ȱ���� ��ҵǸ� ���� �߷�ũ��� ���ƿ�
        else rigid.gravityScale = 2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ����� ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;                // ���� ����� true
            canGlide = true;                // Ȱ�� ���� true
            jumpCount = jumpCountMax;       // ���� Ƚ�� �ʱ�ȭ
            anim.SetBool("isJump", false);  // ���� �ִϸ��̼� false
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������� �¾��� ��
        if (collision.CompareTag("Electro"))
        {
            StartCoroutine(Confused());
        }
        // �������� ������ ��
        if (collision.CompareTag("Guard"))
        {
            gameObject.SetActive(false);
        }
        // Ʈ���� ������ ��
        if (collision.CompareTag("Trap"))
        {
            StartCoroutine(Confused());
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isJump", true);       // ���� �ִϸ��̼� true
        isGround = false;                   // ���� ������� false
    }

    IEnumerator Confused()
    {
        isConfused = true;

        for (int i = 0; i < 50; i++)
        {
            if (spriterenderer.flipX)  spriterenderer.flipX = false;
            else spriterenderer.flipX = true;
            yield return new WaitForSeconds(.05f);
        }
        isConfused = false;
    }
}
