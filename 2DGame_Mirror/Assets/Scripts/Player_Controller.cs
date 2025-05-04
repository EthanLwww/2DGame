using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
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
        animator = GetComponent<Animator>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
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
        if (moveDir != 0)
            animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);
        Jump();
        if (IsGround())
        {
            animator.SetBool("isOnGround", true);
            animator.SetBool("isFalling", false);
        }
        else
        {
            animator.SetBool("isOnGround", false);
        }
        if (Input.GetKeyDown(KeyCode.O))
            animator.SetBool("isDead", true);

        if (Input.GetKeyDown(KeyCode.P))
            animator.SetBool("isRebirthing", true);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        //Vector2 playVel = new Vector2(moveDir * moveSpeed, rb.velocity.y);
        //rb.velocity = playVel;

        transform.Translate(new Vector2(moveDir, 0) * moveSpeed * Time.deltaTime, Space.World);
        if ((facingLeft && moveDir < 0) || (!facingLeft && moveDir > 0))
        {
            facingLeft = !facingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }

    void Jump()
    {
        Debug.Log(IsGround());
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround()) //第一段跳
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                animator.SetBool("isJumping", true);
                isJumping = true;
                jumpContinue = 0;
                isDoubleJump = true;
            }
            else if (isDoubleJump)
            {
                animator.SetBool("isDoubleJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * 0.75f);
                isJumping = true;
                jumpContinue = 0;
                isDoubleJump = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpContinue += Time.deltaTime;
            if (jumpContinue > jumpTime)
            {
                isJumping = false;
            }
            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isFalling", true);
        }
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.87f, 2.60f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }
}
