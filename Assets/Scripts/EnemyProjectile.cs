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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Knight") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player
        }
        else if (other.gameObject.CompareTag("Rogue") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //no enemy friendly fire
        }
        else
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(5);
            Destroy(gameObject);
        }
    }
}
