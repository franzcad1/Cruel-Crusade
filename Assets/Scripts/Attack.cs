using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   
    private bool hasEnemy = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            hasEnemy = true;

        if(hasEnemy && Input.GetMouseButtonDown(0))
        {
            if(Input.GetAxis("Jump") > 0)
            {
                ////Temporary Don´t destroy while Knight is in Shield 
                /////to be replaced with 75% less damage rutine
                
            }
            else
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            hasEnemy = true;
        if (hasEnemy && Input.GetMouseButtonDown(0))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            hasEnemy = false;
    }
  
}
