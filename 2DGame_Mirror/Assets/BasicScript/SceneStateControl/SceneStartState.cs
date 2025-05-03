//Author : EthanLiu
//CreateTime : 2025-02-14-20:34:10
//Version : 1.0
//UnityVersion : 2021.3.45f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartState : ISceneState
{
    public SceneStartState (SceneStateControl control):base(control){
        this.StateName = "SceneStartState";
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
