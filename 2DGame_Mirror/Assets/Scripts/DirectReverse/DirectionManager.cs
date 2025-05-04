/*
Created:2025/5/3
Author:Li Yinwei
email:li_yinwei@foxmail.com
This file is used to control the direction of the game object and its children.
Press 'K' to reverse the Object and its childrens' position.Like a mirror.
You need to attach this script to a game object whose x-axis is 0.
Remember that the child of the game object you attach to could not have his child too.Which means your game object tree should looks like this:
GameObject
    |── Child1
    |── Child2
    |── Child3
and should not looks like this:
GameObject
    |── Child1
        |── Child1.1 -->this could lead to a bug,I have not fixed it yet.
        |── Child1.2
    |── Child2
    |── Child3
*/
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode trigerKey = KeyCode.K;
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
        if (Input.GetKeyDown(trigerKey))
        {
            Debug.Log("reverse!");
            ReversePosition(go.transform);
        }
    }

    void ReversePosition(Transform parent)
    {
        ////reverse the parent
        //Vector2 parentPosition = parent.position;
        //parentPosition.x = -parentPosition.x;
        //parent.position = parentPosition;
        //Debug.Log($"Reversed position of {parent.name}: {parent.position}");
        ////reverse the children
        //foreach (Transform child in parent)
        //{
        //    Vector2 childPosition = child.localPosition;
        //    childPosition.x = -childPosition.x;
        //    child.localPosition = childPosition;
        //    Debug.Log($"Reversed position of {parent.name}: {parent.position}");

        //}
        parent.localScale = new Vector2(-parent.localScale.x, parent.localScale.y);


    }

}
