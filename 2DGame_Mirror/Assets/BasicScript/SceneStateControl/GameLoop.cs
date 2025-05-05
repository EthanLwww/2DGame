//Author : EthanLiu
//CreateTime : 2025-02-14-19:12:46
//Version : 1.0
//UnityVersion : 2021.3.45f1c1

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLoop : SingletonBase<GameLoop>
{
    [SerializeField]
    private SceneStateControl sceneStateControl = new SceneStateControl();
    public override void Awake()
    {
        base.Awake();
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    private void Start()
    {
        sceneStateControl.SetState(new SceneStartState(sceneStateControl));
    }

    private void Update()
    {
        sceneStateControl.StateUpdate();
    }
}
