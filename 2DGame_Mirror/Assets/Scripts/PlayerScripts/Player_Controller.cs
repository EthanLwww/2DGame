using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    /*��ɫ��Ծ������*/
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    bool isDoubleJump;

    Vector2 vecGravity;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    float jumpContinue;
    bool isJumping;

    /*��ɫ�Զ�ת�������*/
    bool facingLeft = true;
    float moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//��õ�ǰ��ɫ����

        vecGravity = new Vector2(0,-Physics2D.gravity.y);
        groundCheck = gameObject.transform;
        //init
        moveSpeed = 4f;
        jumpSpeed = 6f;
        jumpMultiplier = 4f;
        fallMultiplier = 1f;
        jumpTime = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {

        moveDir = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        //Vector2 playVel = new Vector2(moveDir * moveSpeed,rb.velocity.y);
        //rb.velocity = playVel;
        //ԭʹ�ø����ٶȵ��ƶ������ᵼ�°�ס�������ʱ���ɫճ��ǽ���²�������Ϊ�������������ʵͦ�ٵġ�
        gameObject.transform.Translate(new Vector2(moveDir * moveSpeed * Time.deltaTime,0), Space.World);
        if((facingLeft && moveDir<0)||(!facingLeft&&moveDir>0))
        {
            facingLeft = !facingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }

    void Jump()
    {
        Debug.Log(IsGround());
        if(Input.GetButtonDown("Jump"))
        {
            if(IsGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                isJumping = true;
                jumpContinue = 0;
                isDoubleJump = true;
            }else if(isDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed*0.75f);
                isJumping = true;
                jumpContinue = 0;
                isDoubleJump = false;
            }
            
        }

        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if(rb.velocity.y > 0 && isJumping)
        {
            jumpContinue += Time.deltaTime;
            if(jumpContinue > jumpTime)
            {
                isJumping = false;
            }
            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }

    private bool IsGround()
    {

        return Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.87f, 2.60f),CapsuleDirection2D.Vertical,0,groundLayer);
    }
}
