using UnityEngine;
using UnityEngine.UIElements;
public class Fall_and_back : MonoBehaviour
{
    public static int count = 0;
    public Transform playerPosition;    //��ȡ��ҵ�ǰλ��
    public static Vector2 playerNowPosition;    //��¼������
    private void OnTriggerEnter2D(Collider2D other)
    {
        count++;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("����");
            CodePoint();
            gameObject.SetActive(false);
        }

    }

    //����Ҵ����浵���λ������Ϊ����λ��
    public void CodePoint()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        playerNowPosition = playerPosition.transform.position;      
    }
}



