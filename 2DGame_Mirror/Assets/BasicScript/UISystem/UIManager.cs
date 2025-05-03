//Author : EthanLiu
//CreateTime : 2025-05-03-16:43
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager :SingletonBase<UIManager>
{
    public List<string> UIPanelNames = new();
    public Dictionary<string, PanelBase> UIDic = new();
    public Dictionary<string, PanelBase> existingUIDIc = new();

    private Transform canvasTrans;

    public override void Awake()
    {
        base.Awake();
        canvasTrans = GameObject.Find("Canvas").transform;
        if(canvasTrans == null)
        {
            GameObject canvas = new();
            canvas.AddComponent<Canvas>();
            canvasTrans = canvas.transform;
        }
    }

    #region ShowUI����
    public void ShowUI(string panelName)  //�˴�����Ҫ����Ԥ��������һ��
    {
        if(!UIPanelNames.Contains(panelName))
        {
            GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
            if (panelObj != null)
            {
                panelObj.transform.SetParent(canvasTrans, false);

                PanelBase panel = panelObj.GetComponent<PanelBase>();

                UIPanelNames.Add(panelName);
                UIDic.Add(panelName, panel);
            }
            else
            {
                Debug.Log("Can't Find Panel" + panelName + "!");
                return;
            }
        }

        existingUIDIc.Add(panelName, UIDic[panelName]);
        UIDic[panelName].Show();
    }

    public void ShowUI(string panelName, UnityAction callback)  //���ص�������
    {
        if (!UIPanelNames.Contains(panelName))
        {
            GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
            if (panelObj != null)
            {
                panelObj.transform.SetParent(canvasTrans, false);

                PanelBase panel = panelObj.GetComponent<PanelBase>();

                UIPanelNames.Add(panelName);
                UIDic.Add(panelName, panel);
            }
            else
            {
                Debug.Log("Can't Find Panel" + panelName + "!");
                return;
            }
        }

        existingUIDIc.Add(panelName, UIDic[panelName]);
        UIDic[panelName].Show(callback);
    }
    #endregion

    #region HideUI����

    public void HideUI(string panelName)       //�˴�����Ҫ����Ԥ��������һ��
    {
        if(!existingUIDIc.ContainsKey(panelName))
        {
            Debug.Log("The Panel" + panelName + "Is Not Showing!");
        }
        else
        {
            existingUIDIc[panelName].Hide();
            existingUIDIc.Remove(panelName);
        }

    }

    public void HideUI(string panelName,UnityAction callBack)  //���ص�������
    {
        if (!existingUIDIc.ContainsKey(panelName))
        {
            Debug.Log("The Panel" + panelName + "Is Not Showing!");
        }
        else
        {
            existingUIDIc[panelName].Hide(callBack);
            existingUIDIc.Remove(panelName);
        }

    }
    #endregion

    public PanelBase GetUI(string panelName)
    {
        if (!UIPanelNames.Contains(panelName))
        {
            GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));
            if (panelObj != null)
            {
                panelObj.transform.SetParent(canvasTrans, false);

                PanelBase panel = panelObj.GetComponent<PanelBase>();

                UIPanelNames.Add(panelName);
                UIDic.Add(panelName, panel);
                return UIDic[panelName];
            }
            else
            {
                Debug.Log("Can't Find Panel" + panelName + "!");
                return null;
            }
        }
        else return UIDic[panelName];

    }
}
