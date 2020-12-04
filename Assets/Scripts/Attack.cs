using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   
    private bool hasEnemy = false;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject beholder;
    private GameObject timeline;

    void Start()
    {
        timeline = GameObject.Find("BeholderTimeline");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && Input.GetMouseButtonDown(0))
        {
            Destroy(enemy);
        }

        else if (beholder != null && Input.GetMouseButtonDown(0) && timeline.GetComponent<BeholderTimeline>().isDamageable)
        {
            timeline.GetComponent<BeholderTimeline>().health--;
            timeline.GetComponent<BeholderTimeline>().isDamageable = false;
            timeline.GetComponent<BeholderTimeline>().anim.SetBool("Damaged", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = collision.gameObject;
        }
        else if(collision.gameObject.CompareTag("Beholder") && !collision.isTrigger)
        {
            beholder = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Beholder") && !collision.isTrigger)
        {
            beholder = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
            enemy = null;
        }
        else if (collision.gameObject.CompareTag("Beholder") && !collision.isTrigger)
        {
            beholder = null;
        }
    }
}