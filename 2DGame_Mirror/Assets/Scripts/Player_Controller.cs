using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public static int sceneIndex = 1;

    public AudioSource jumpAudio;
    public AudioSource moveAudio;
    public AudioSource deadAudio;

    private PlayerInputAction controls;
    private Vector2 move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//获取当前角色刚体
        controls = new PlayerInputAction();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        controls.PlayerAction.Enable();
    }
    void OnDisable()
    {
        controls.PlayerAction.Disable();
    }


    [Header("玩家设置基本属性设置")]
    //角色跳跃的设置
    [SerializeField]private float moveSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpSpeed;
    bool isDoubleJump;

    Vector2 vecGravity;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    float jumpContinue;
    bool isJumping;

    //角色自动转向的设置
    bool facingLeft = true;

    bool canMove = true;
    public Vector3 rebirthPos;
    public bool isGet2Garget = false;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        groundCheck = gameObject.transform;
        moveSpeed = 249f;
        jumpSpeed = 6f;
        jumpMultiplier = 4f;
        fallMultiplier = 0.07f;
        jumpTime = 0.2f;
        isGet2Garget = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Jump_Check.OnGround);
        jump();
        if (canMove)
            move = controls.PlayerAction.Move.ReadValue<Vector2>();
        else move.x = 0;
        if (move.x != 0)
            animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);


        if (Jump_Check.OnGround && canMove)
        {
            animator.SetBool("isOnGround", true);
            animator.SetBool("isFalling", false);
        }
        else
        {
            animator.SetBool("isOnGround", false);
        }
        /*if (Input.GetKeyDown(KeyCode.O))
            animator.SetBool("isDead", true);

        if (Input.GetKeyDown(KeyCode.P))
            animator.SetBool("isRebirthing", true);*/
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        rb.velocity = new Vector2(move.x * moveSpeed * Time.deltaTime, rb.velocity.y) ;
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        if (Jump_Check.OnGround == false || move.x == 0)
        {
            moveAudio.Stop();
        }
        //rb.velocity = new Vector2(move.x * moveSpeed * Time.deltaTime, rb.velocity.y) ;
        transform.Translate(new Vector2(move.x ,0) * moveSpeed * Time.deltaTime, Space.World);
>>>>>>> Stashed changes
        if ((facingLeft && move.x < 0) || (!facingLeft && move.x > 0))
        {
            moveAudio.Play();
            facingLeft = !facingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

    }


    private void jump()
    {
        controls.PlayerAction.Jump.started += JumpIn;
        controls.PlayerAction.Jump.canceled += JumpOut;
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

        if (Jump_Check.OnGround)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isFalling", false);
            animator.SetBool("isOnGround", true);
        }
    }
    private void JumpIn(InputAction.CallbackContext context)
    {
        if (Jump_Check.OnGround) //第一段跳
        {
            jumpAudio.Play();
            Jump_Check.OnGround = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
            isJumping = true;
            jumpContinue = 0;
            isDoubleJump = true;
        }
        //检测是否是二段跳便设置跳跃次数极限为2
        else if (isDoubleJump)
        {
            jumpAudio.Play();
            animator.SetBool("isDoubleJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * 0.75f);
            isJumping = true;
            jumpContinue = 0;
            isDoubleJump = false;
        }

    }

    private void JumpOut(InputAction.CallbackContext context)
    {
        isJumping = false;
    }

    public void Die()
    {
        deadAudio.Play();
        animator.SetBool("isDead", true);
        canMove = false;
        IEnumeratorSystem.Instance.startCoroutine(DieTimer());
    }

    IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(0.33f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        animator.SetBool("isDead", false);
        Rebirth();
    }

    public void Rebirth()
    {
        gameObject.SetActive(true);
        transform.position = rebirthPos;
        animator.SetBool("isRebirthing", true);
        IEnumeratorSystem.Instance.startCoroutine(RebirthTimer());
    }

    IEnumerator RebirthTimer()
    {
        yield return new WaitForSeconds(0.41f);
        animator.SetBool("isRebirthing", false);
        canMove = true;
    }

}

