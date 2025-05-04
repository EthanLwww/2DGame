using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fall_and_back : MonoBehaviour
{
    [SerializeField] public Transform playerPosition;
    [SerializeField] public Transform playerNowPosition; //记录重生点
    public static Fall_and_back instance{ get;private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("进入");
            codePoint();
            gameObject.SetActive(false);
        }
        
    }

    public void codePoint()
    {
        playerNowPosition.transform.position = playerPosition.transform.position;
    }
}
