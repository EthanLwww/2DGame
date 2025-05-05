using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Ground")
        {
            transform.root.GetComponent<Player_Controller>().Die();
            Debug.Log("¿¨×¡ÁË");
        }
    }
}
