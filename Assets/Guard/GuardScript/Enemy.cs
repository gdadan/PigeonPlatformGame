using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] float rightMax = 5f;
    [SerializeField] float leftMax = -5f;
    [SerializeField] float moveSpeed = 3f;

    float direction = 1f;
    public GameObject player;

    SpriteRenderer spriteRenderer;
    Animator anim;

    float currentX;
    float guardSpeed = 5f;
    float followCooltime = 0f;
    float stoppingDistance = 0.5f;

    public string state = "Move";
    public GameObject cctv;
    
    bool isMoving = true;
    bool isWaiting = false;

    Vector2 oriPos;
  
    void Start()
    {
        currentX = transform.position.x;
        oriPos = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        switch (state)
        {
            case "Move":
                isMoving = true;                
                Movement();
                break;

            case "Follow":
                Follow();
                break;

            case "CCTVMove":
                MoveCCTV();
                break;
        }
    }

    void Movement()
    {
        transform.position += Vector3.right * Time.deltaTime * direction * guardSpeed;

        if (transform.position.x >= currentX + rightMax)
        {
            direction *= -1;
            transform.position = new Vector3(currentX + rightMax, transform.position.y, 0);
            spriteRenderer.flipX = false;
        }

        else if (transform.position.x <= currentX + leftMax)
        {
            direction *= -1;
            transform.position = new Vector3(currentX + leftMax,transform.position.y, 0);
            spriteRenderer.flipX = true;
        }
    }

    void Follow()
    {             
        float x_value = player.transform.position.x - transform.position.x;
        followCooltime += Time.deltaTime;
        anim.SetBool("chase", true);
      
        if (followCooltime >= 5)
        {
            currentX = transform.position.x;
            state = "Move";
            anim.SetBool("chase", false);
            followCooltime = 0;
        }

        if (x_value > 0) transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        else transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        anim.SetBool("surprised", false);
    }

    public void MoveCCTV()
    {
        if (isMoving)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            float distance = Vector2.Distance(transform.position, cctv.transform.position);
            Vector2 direction = (cctv.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            if (distance < stoppingDistance)
            {
                isMoving = false;
                isWaiting = false;
                StartCoroutine(WaitTime());
            }
        }
        if (isWaiting)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Vector2 direction2 = (oriPos - (Vector2)transform.position).normalized;
            transform.Translate(direction2 * moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, oriPos) < stoppingDistance)
            {
                isWaiting = false;
                state = "move";
            }
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        isWaiting = true;
    }

}
