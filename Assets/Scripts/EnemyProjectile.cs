using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            //destroy this object hitting walls
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Knight") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player, destroy this object
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Rogue") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player, destroy this object
            Destroy(gameObject);
        }
        //else if (other.gameObject.CompareTag("Enemy"))
        //{
        //    //no enemy friendly fire, destroy this object
        //    Destroy(gameObject);
        //}
        else if (other.gameObject.CompareTag("Rogue") || other.gameObject.CompareTag("Knight") || other.gameObject.CompareTag("Barbarian"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(5);
            Destroy(gameObject);
        }
    }
}
