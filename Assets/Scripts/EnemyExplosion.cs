using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyExplosion : MonoBehaviour
{
    public float selfDestructTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyThis());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator destroyThis()
    {
        //destroy this object after time
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Object reference not set to an instance of an object DestroyByContact.OnCollisionEnter2D
        //fixed by making controllerS public and attaching game controllerobject
        //Instantiate(death, other.gameObject.GetComponent<Rigidbody2D>().position, this.transform.rotation);
        if (other.gameObject.CompareTag("Walls"))
        {
            //do not destroy ground
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
            //no enemy friendlyfire
        }
        else
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(5);
        }
    }
}
