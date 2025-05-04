using UnityEngine;
using UnityEngine.UIElements;
public class Fall_and_back : MonoBehaviour
{
    public static int count = 0;
    public Transform playerPosition;    //获取玩家当前位置
    public static Vector2 playerNowPosition;    //记录重生点
    private void OnTriggerEnter2D(Collider2D other)
    {
        count++;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("进入");
            CodePoint();
            gameObject.SetActive(false);
        }

    }

    //将玩家触发存档点的位置设置为复活位置
    public void CodePoint()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        playerNowPosition = playerPosition.transform.position;      
    }
}



