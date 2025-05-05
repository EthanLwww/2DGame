using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Check : MonoBehaviour
{
    CapsuleCollider2D groundCheck;
    public static bool OnGround = true;

    private void Awake()
    {
        groundCheck = GetComponent<CapsuleCollider2D>();
    }



    void Update()
    {
        //OnTriggerEnter2D(groundCheck);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            OnGround = true;
            Transform parentTransform = transform.root;
            parentTransform.GetComponent<Rigidbody2D>().velocity = new Vector2(parentTransform.GetComponent<Rigidbody2D>().velocity.x,1);
        }
        else
        {
            OnGround= false;
        }
    }
}
