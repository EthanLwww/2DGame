using UnityEngine;

public class Fall_and_back : MonoBehaviour
{
    public Transform playerPosition;
    public Transform playerNowPosition; //记录重生点

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("进入");
            CodePoint();
            gameObject.SetActive(false);
        }

    }

    public void CodePoint()
    {
        playerNowPosition.transform.position = playerPosition.transform.position;
    }
}
