using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   
    private bool hasEnemy = false;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && Input.GetMouseButtonDown(0))
        {
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = null;
        }
    }
}