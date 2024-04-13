using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Animator anim;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3 (moveX, moveY, 0);

        if (moveVec == Vector3.zero) anim.SetBool("isMove", false);
        else anim.SetBool("isMove", true);

        if (moveX > 0) spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;

        transform.position += moveVec * Time.deltaTime * moveSpeed;
    }


}
