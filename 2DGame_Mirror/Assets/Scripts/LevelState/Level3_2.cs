//Author : EthanLiu
//CreateTime : 2025-5-5-0:20
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_2 : ISceneState
{
    private Player_Controller player;
    public Vector3 respawnPos = new(-5.5f, -2.5f, 0);
    private DirectionManager directionManager;
    private GameObject canvas;
    public Level3_2(SceneStateControl control) : base(control)
    {
        this.StateName = "Level3_2";
    }

    public override void StateBegin()
    {
        player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), respawnPos, Quaternion.identity).GetComponent<Player_Controller>();
        player.rebirthPos = respawnPos;
        player.canDoubleJump = true;
        directionManager = Transform.FindObjectOfType<DirectionManager>();
        directionManager.canOverUpAndDown = true;
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }
    public override void StateEnd()
    {
        Object.Destroy(player.gameObject);
    }
    public override void StateUpdate()
    {
        if (player.isGet2Garget == true)
        {
            // my_control.SetState(new Level4_1(my_control), "Level4_1");
            Debug.Log("Ã»¹Ø¿¨ÁË");
            canvas.SetActive(true);
        }
    }
}