using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject pp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //spawnpoint.transform.position = Fall_and_back.instance.playerNowPosition.transform.position;
            Invoke(nameof(SetPlayerPosition), 1f);
        }
    }

    public void SetPlayerPosition()
    {
        pp.transform.position = new Vector2(spawnpoint.transform.position.x, spawnpoint.transform.position.y);
    }
}
