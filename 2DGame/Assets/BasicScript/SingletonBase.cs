//Author : EthanLiu
//CreateTime : 2025-05-02-10:29
//Version : 1.0
//UnityVersion : 2021.3.16f1c1

using UnityEngine;
public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
{
    private static T instance;
    private static object locker = new object();
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (locker)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        Debug.Log("Singleton" + typeof(T) + "has been created!");
                        GameObject obj = new("" + typeof(T));
                        instance = obj.AddComponent<T>();
                        DontDestroyOnLoad(obj);
                    }
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }

    }


}
