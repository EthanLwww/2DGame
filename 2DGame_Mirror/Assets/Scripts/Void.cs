using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_Controller>().Die();
        }
    }
}
