//Author : EthanLiu
//CreateTime : 2025-05-03-17:14
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public abstract class PanelBase : MonoBehaviour
{
    public Dictionary<string, MonoBase> monos = new();
    public UnityAction showCallBack;
    public UnityAction hideCallBack;

    public void Register(MonoBase mono)
    {
        string monoName = mono.GetType().Name;
        if (monos.ContainsKey(monoName))
        {
            Debug.Log(monoName + "Is Already Existed!");
        }
        else
        {
            monos.Add(monoName, mono);
            Debug.Log(monoName + "Has Added!");
        }
    }

    public MonoBase GetMono(string monoName)
    {
        if (monos.ContainsKey(monoName))
        {
            return monos[monoName];
        }
        else
        {
            return null;
        }
    }

    protected virtual void Start()
    {
        Init();
    }
    public abstract void Init();    //在子类中一定要重写

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Show(UnityAction callback)
    {
        gameObject.SetActive(true);
        showCallBack = callback;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Hide(UnityAction callBack)
    {
        gameObject.SetActive(false);
        hideCallBack = callBack;
    }
}
