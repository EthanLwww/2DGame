//Author : EthanLiu
//CreateTime : 2025-5-5-0:20
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_1 : ISceneState
{
    private Player_Controller player;
    public Vector3 respawnPos;
    public Level4_1(SceneStateControl control) : base(control)
    {
        this.StateName = "Level4_1";
    }

    public override void StateBegin()
    {

    }
    public override void StateEnd()
    {

    }
    public override void StateUpdate()
    {

    }
}