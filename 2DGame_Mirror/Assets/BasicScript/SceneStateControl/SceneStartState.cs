//Author : EthanLiu
//CreateTime : 2025-02-14-20:34:10
//Version : 1.0
//UnityVersion : 2021.3.45f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStartState : ISceneState
{
    private Button button;
    public SceneStartState (SceneStateControl control):base(control){
        this.StateName = "SceneStartState";
    }


    public override void StateBegin()
    {
        button = GameObject.Find("startgame").GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }
    public override void StateEnd()
    {

    }
    public override void StateUpdate()
    {

    }

    public void StartGame()
    {
        my_control.SetState(new Level1_1(my_control), "Level1_1");
    }
}
