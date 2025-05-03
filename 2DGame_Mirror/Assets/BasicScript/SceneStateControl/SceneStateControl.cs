//Author : EthanLiu
//CreateTime : 2025-02-14-19:32:53
//Version : 1.0
//UnityVersion : 2021.3.45f1c1

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneStateControl
{
    [SerializeField]
    private ISceneState currentState = null;
    [SerializeField]
    private bool stateBegin =false;
    [SerializeField]
    private bool isLoadingScene = false;

    public void SetState(ISceneState state,string SceneName)
    {
        Debug.Log("SetState : " + state.ToString());
        stateBegin =false;
        IEnumeratorSystem.Instance.startCoroutine(LoadScene(SceneName),"LoadScene : " + SceneName);

        if (currentState != null)
        {
            currentState.StateEnd();
        }

        currentState = state;
    }
    IEnumerator LoadScene(string SceneName)
    {
        if (SceneName == null || SceneName.Length == 0) { yield break; }
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName);
        isLoadingScene = true;
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        isLoadingScene = false ;
    }



    public void StateUpdate()
    {
        if(currentState == null||isLoadingScene) { return; }
        if (!stateBegin) {
            currentState.StateBegin();
            stateBegin = true;
        }
        currentState.StateUpdate();
    }
}
