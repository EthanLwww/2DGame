using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    /*角色跳跃的设置*/
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

    /*角色自动转向的设置*/
    bool facingLeft = true;
    float moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//获得当前角色刚体

        vecGravity = new Vector2(0,-Physics2D.gravity.y);
        
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
        
        Vector2 playVel = new Vector2(moveDir * moveSpeed,rb.velocity.y);
        rb.velocity = playVel;
        if((facingLeft && moveDir>0)||(!facingLeft&&moveDir<0))
        {
            facingLeft = !facingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }

    void Jump()
    {
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

        if(rb.velocity.y > 0&&isJumping)
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

        return Physics2D.OverlapCapsule(groundCheck.position,new Vector2(0.6f, 0.03f),CapsuleDirection2D.Horizontal,0,groundLayer);
    }
}
