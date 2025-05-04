/*
Created:2025/5/3
Author:Li Yinwei
email:li_yinwei@foxmail.com
This file is used to control the direction of the game object and its children.
Press 'K' to reverse the Object and its childrens' position.Like a mirror.
You need to attach this script to a game object whose x-axis is 0 and y-axis is 0 either.
The game object can have recursion child objects.
*/
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    [Header("Key to trigger the reverse direction")]
    public KeyCode horizonTrigerKey = KeyCode.K;
    public KeyCode verticalTrigerKey = KeyCode.J;
    private GameObject go;
    private Rigidbody2D rb;
    void Start()
    {
        //get the game object
        go = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(horizonTrigerKey))
        {
            Debug.Log("reverse horizon!");
            ReverseHorizonPosition(go.transform);
        }
        if (Input.GetKeyDown(verticalTrigerKey))
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
