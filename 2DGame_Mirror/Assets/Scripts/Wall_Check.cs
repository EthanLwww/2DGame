using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall_Check : MonoBehaviour
{
    BoxCollider2D wallCheck;
    private void Start()
    {
        
    }

    private void Awake()
    {
        wallCheck = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            Transform parentTransform = transform.parent;
            parentTransform.GetComponent<Player_Controller>().Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
