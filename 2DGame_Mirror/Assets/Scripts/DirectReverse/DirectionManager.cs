/*
Created:2025/5/3
Author:Li Yinwei
email:li_yinwei@foxmail.com
This file is used to control the direction of the game object and its children.
Press 'K' to reverse the Object and its childrens' position.Like a mirror.
You need to attach this script to a game object whose x-axis is 0 and y-axis is 0 either.
The game object can have recursion child objects.
*/
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DirectionManager : MonoBehaviour
{
    private PlayerInputAction controls;

    private void Awake()
    {
        controls = new PlayerInputAction();

    }
    private void OnEnable()
    {
        controls.PlayerAction.Enable();
    }
    void OnDisable()
    {
        controls.PlayerAction.Disable();
    }


    [Header("Key to trigger the reverse direction")]
    private GameObject go;
    private Rigidbody2D rb;
    public bool canOverUpAndDown;
    void Start()
    {
        //get the game object
        go = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        controls.PlayerAction.Overturn.performed += overLeftAndRight;
        controls.PlayerAction.OverturnUAD.performed += overUpAndDown;

    }



    private void overLeftAndRight(InputAction.CallbackContext context)
    {
        Debug.Log("reverse horizon!");
        ReverseHorizonPosition(go.transform);
    }

    private void overUpAndDown(InputAction.CallbackContext context)
    {
        if (canOverUpAndDown)
        {
            Debug.Log("reverse vertical!");
            ReverseVerticalPosition(go.transform);
        }
    }


    void ReverseHorizonPosition(Transform parent)
    {
        parent.localScale = new Vector2(-parent.localScale.x, parent.localScale.y);
    }
    void ReverseVerticalPosition(Transform parent)
    {
        parent.localScale = new Vector2(parent.localScale.x, -parent.localScale.y);
    }
}
