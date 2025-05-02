//Author : EthanLiu
//CreateTime : 2025-05-02-11;17
//Version : 1.0
//UnityVersion : 2021.3.16f1c1


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorSystem : SingletonBase<IEnumeratorSystem>
{
    public List<IEnumerator> allCoroutines = new List<IEnumerator>();
    public List<string> allCoroutinesName = new List<string>();
    public Dictionary<string, Coroutine> CoroutineDic = new Dictionary<string, Coroutine>();

    public void startCoroutine(IEnumerator enumerator)
    {
        allCoroutines.Add(enumerator);
        string name = enumerator.GetType().Name;
        string temp = name;
        int index = 0;
        while (allCoroutinesName.Contains(name))
        {
            index++;
            name = temp + "_" + index;
        }
        allCoroutinesName.Add(name);
        CoroutineDic.Add(name, StartCoroutine(outIEnumerator(enumerator, name)));
    }

    public void startCoroutine(IEnumerator enumerator, string name)
    {
        allCoroutines.Add(enumerator);
        int index = 0;
        while (allCoroutinesName.Contains(name))
        {
            index++;
            name = name + "_" + index;
        }
        allCoroutinesName.Add(name);
        CoroutineDic.Add(name, StartCoroutine(outIEnumerator(enumerator, name)));
    }

    IEnumerator outIEnumerator(IEnumerator enumerator, string name)
    {
        yield return enumerator;
        endCallBack(enumerator, name);
    }
    void endCallBack(IEnumerator enumerator, string name)
    {
        allCoroutines.Remove(enumerator);
        allCoroutinesName.Remove(name);
        CoroutineDic.Remove(name);
    }

    public void stopCoroutine(string name)
    {
        if (!allCoroutinesName.Contains(name))
        {
            Debug.Log("IEnumerator" + name + "Is Not Contained!");
            return;
        }
        StopCoroutine(CoroutineDic[name]);
        allCoroutines.RemoveAt(allCoroutinesName.FindIndex(x => x == name));
        allCoroutinesName.Remove(name);
        CoroutineDic.Remove(name);
    }
    public void stopCoroutine(IEnumerator enumerator)
    {
        if (!allCoroutines.Contains(enumerator))
        {
            Debug.Log("IEnumerator" + enumerator.GetType().Name + "Is Not Contained!");
            return;
        }
        string name = allCoroutinesName[allCoroutines.FindIndex(x => x == enumerator)];
        StopCoroutine(CoroutineDic[name]);
        allCoroutines.Remove(enumerator);
        allCoroutinesName.Remove(name);
        CoroutineDic.Remove(name);
    }
}
