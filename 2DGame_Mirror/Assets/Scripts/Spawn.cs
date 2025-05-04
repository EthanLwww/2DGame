using UnityEngine;
public class Spawn : MonoBehaviour
{
    public Vector2 spawnpoint;
    public GameObject pp;
    private Vector2 playerPosition;
    void Start()
    {
        spawnpoint = pp.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Fall_and_back.count == 0)
        {
            Invoke(nameof(SetPlayerPosition), 1f);
        }
        else if (other.gameObject.CompareTag("Player"))
        {

            spawnpoint = Fall_and_back.playerNowPosition;
            Invoke(nameof(SetPlayerPosition), 1f);
        }
    }

    public void SetPlayerPosition()
    {
        Rigidbody2D rb = pp.GetComponent<Rigidbody2D>();
        pp.transform.position = new Vector2(spawnpoint.x, spawnpoint.y);
        rb.velocity = new Vector2(0, 0);
    }
}
