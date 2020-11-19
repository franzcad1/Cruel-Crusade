using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    // "Public" variables

    //[SerializeField] private bool dirRight = true;
    [SerializeField] private float speed = 0.1f;
    //[SerializeField] private float distance = 4.0f;
    private float initialx;
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private GameObject player;




    //Private Variables
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        initialx = rBody.position.x;
        if (GameObject.FindGameObjectWithTag("Knight") != null)
        {
            player = GameObject.FindGameObjectWithTag("Knight");
        }
        else if (GameObject.FindGameObjectWithTag("Rogue") != null)
        {
            player = GameObject.FindGameObjectWithTag("Rogue");
        }
    }

    //Physics
    private void FixedUpdate()
    {
        //if (dirRight)
        //    rBody.velocity = new Vector2(speed * 10f, 0);
        //else
        //    rBody.velocity = new Vector2(-speed * 10f, 0);

        //if (rBody.position.x >= initialx + distance)
        //{
        //    dirRight = false;
        //}

        //if (rBody.position.x <= initialx - distance)
        //{
        //    dirRight = true;
        //}

        if (playerInRange)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue")
        {
            playerInRange = false;
        }
    }
}
