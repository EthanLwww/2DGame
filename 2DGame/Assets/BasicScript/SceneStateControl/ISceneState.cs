//Author : EthanLiu
//CreateTime : 2025-02-12-13:40:23
//Version : 1.0
//UnityVersion : 2021.3.45f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState
{
    private string my_state_name = "ISceneState";
    public string StateName
    {
        get { return my_state_name; }
        set { my_state_name = value; }
    }
    protected SceneStateControl my_control = null;
    public ISceneState(SceneStateControl control)
    {
        my_control = control;
    }

    public virtual void StateUpdate(){ }
    public virtual void StateEnd() { }
    public virtual void StateBegin() { }

    public override string ToString() {
        return string.Format("[I_SceneState : StateName = {0}]",StateName);    }
}
