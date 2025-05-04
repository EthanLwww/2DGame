using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Vector2 spawnpoint;
    public GameObject pp;

    public static Spawn instance { get;private set; }

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
            spawnpoint = Fall_and_back.instance.playerNowPosition.transform.position;
            Invoke("setPlayerPosition",1f);
        }
    }
        
    public void setPlayerPosition()
    {
        pp.transform.position = new Vector2(spawnpoint.x,spawnpoint.y);
    }
}
