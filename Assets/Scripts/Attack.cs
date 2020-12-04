using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    AudioSource sword;
    private bool hasEnemy = false;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        sword = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (enemy != null && Input.GetMouseButtonDown(0))
        {
            Destroy(enemy);
=======
        if (Input.GetMouseButtonDown(0))
        {
            sword.Play();
>>>>>>> Stashed changes
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
<<<<<<< Updated upstream
            enemy = collision.gameObject;
=======
            
            if (Input.GetAxis("Jump") > 0 && collision.gameObject.CompareTag("Knight"))
            {
                ////Temporary Don´t destroy while Knight is in Shield 
                /////to be replaced with 75% less damage rutine
                
            }
            else
            {
                Destroy(collision.gameObject);
            }
            
>>>>>>> Stashed changes
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !collision.isTrigger)
        {
<<<<<<< Updated upstream
            enemy = collision.gameObject;
=======
            
            Destroy(collision.gameObject);
>>>>>>> Stashed changes
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