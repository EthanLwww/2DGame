/*
This Script is used for bullet to destory when it hit the player.
It should be attach to the bullet prefab and I've already done it.
 */

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);//destroy bullet
            Debug.Log("Hit Player!");
        }
    }
}
