using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    [SerializeField] float playerSpeed = 3f;             // 플레이어 이동 속도
    [SerializeField] float jumpPower = 8f;               // 플레이어 점프 세기
    [SerializeField] float gliderGravity = 0.1f;         // 플레이어 점프 세기

    Rigidbody2D rigid;      // 플레이어 RigidBody
    Animator anim;          // 플레이어 Animatior
    SpriteRenderer spriterenderer;
    AudioSource audiosource;

    int jumpCount;          // 점프 횟수
    int jumpCountMax = 2;   // 최대 점프 횟수

    bool isGround = true;       // 땅에 닿아 있는지 확인(점프, 활공 시 false)
    bool canGlide = true;       // 활공을 할 수 있는지 확인(활공은 공중에 있을 때 한 번 가능)
    bool isConfused = false;    // 레이저에 맞아 혼란상태인지 확인
    bool isRight = true;        // 오른쪽을 바라봄

    public AudioClip walkSource, jumpSource;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();                            // 플레이어 RigidBody
        anim = GetComponent<Animator>();                                // 플레이어 Animator
        spriterenderer = GetComponent<SpriteRenderer>();                // 플레이어 SpriteRenderer
        audiosource = GetComponent<AudioSource>();

        jumpCount = jumpCountMax;           // 점프 횟수를 최대 점프 횟수로 초기화
        rigid.gravityScale = 2f;            // 기본 중력 크기를 2배로 함
    }

    private void Update()
    {
        if (isConfused) return;
        Move();
        Jump();
        Gliding();
    }

    // 플레이어 움직임
    void Move()
    {
        float moveAxisX = Input.GetAxis("Horizontal");

        // 왼쪽으로 이동할 때 왼쪽을 바라봄
        // 오른쪽으로 이동할 때 오른쪽을 바라봄
        if (moveAxisX < 0 && isRight) isRight = false;
        else if (moveAxisX > 0 && !isRight) isRight = true;

        if (isRight) spriterenderer.flipX = false;
        else spriterenderer.flipX = true;

        // 가만히 있을 때 이동 애니메이션 false
        if (moveAxisX == 0) anim.SetBool("isMove", false);
        // 움직일 때 이동 애니메이션 true
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

    // 플레이어 점프
    void Jump()
    {
        // X키를 눌렀을 때 점프 횟수가 남아있다면 점프
        if (Input.GetKeyDown(KeyCode.X) && jumpCount > 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            // 점프 횟수 1회 감소
            jumpCount--;

            audiosource.clip = jumpSource;
            audiosource.Play();
        }
    }

    // 플레이어 활공
    void Gliding()
    {
        // Z키를 누르면 활공 시작(점프하던 힘을 삭제)
        if (Input.GetKeyDown(KeyCode.Z) && canGlide) rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // Z키를 계속 누르고 있으면 활공(중력 크기를 줄임)
        else if (Input.GetKey(KeyCode.Z) && !isGround && canGlide)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.clip = jumpSource;
                audiosource.Play();
            }
            rigid.gravityScale = gliderGravity;
        }
        // Z키를 떼면 활공 불가능 상태로 만듦
        else if (Input.GetKeyUp(KeyCode.Z)) canGlide = false;
        // 활공이 취소되면 원래 중력크기로 돌아옴
        else rigid.gravityScale = 2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 땅에 닿았을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;                // 땅에 닿았음 true
            canGlide = true;                // 활공 가능 true
            jumpCount = jumpCountMax;       // 점프 횟수 초기화
            anim.SetBool("isJump", false);  // 점프 애니메이션 false
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 레이저에 맞았을 때
        if (collision.CompareTag("Electro"))
        {
            StartCoroutine(Confused());
        }
        // 경비원에게 잡혔을 때
        if (collision.CompareTag("Guard"))
        {
            gameObject.SetActive(false);
        }
        // 트랩에 잡혔을 때
        if (collision.CompareTag("Trap"))
        {
            StartCoroutine(Confused());
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("isJump", true);       // 점프 애니메이션 true
        isGround = false;                   // 땅에 닿았으면 false
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
