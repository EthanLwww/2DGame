using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource winAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Player")
        {
            winAudio.Play();
            collision.GetComponent<Player_Controller>().isGet2Garget = true;
            Debug.Log("isGet2target");
        }
    }
}
