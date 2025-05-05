//Author : EthanLiu
//CreateTime : 2025-5-5-0:20
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_1 : ISceneState
{
    private Player_Controller player;
    public Vector3 respawnPos = new(-5.5f, -1.5f, 0);
    private DirectionManager directionManager;
    public Level2_1(SceneStateControl control) : base(control)
    {
        this.StateName = "Level2_1";
    }
    public override void StateBegin()
    {
        player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), respawnPos, Quaternion.identity).GetComponent<Player_Controller>();
        player.rebirthPos = respawnPos;
        player.canDoubleJump = false;
        directionManager = Transform.FindObjectOfType<DirectionManager>();
        directionManager.canOverUpAndDown = true;
    }
    public override void StateEnd()
    {
        Object.Destroy(player.gameObject);
    }
    public override void StateUpdate()
    {
        if (player.isGet2Garget == true)
        {
            my_control.SetState(new Level2_2(my_control), "Level2_2");
        }
    }
}