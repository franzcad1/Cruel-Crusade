using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    // "Public" variables

    //[SerializeField] private bool dirRight = true;
    [SerializeField] public float speed = 0.05f;
    //[SerializeField] private float distance = 4.0f;
    private float initialx;
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private GameObject player;
    [SerializeField] private MonoBehaviour AOEscript;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sound;




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
        else if (GameObject.FindGameObjectWithTag("Barbarian") != null)
        {
            player = GameObject.FindGameObjectWithTag("Barbarian");
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
        if (animator != null)
        {
            animator.SetFloat("MoveX", rBody.velocity.x);
            animator.SetFloat("MoveY", rBody.velocity.y);
            if (rBody.velocity.y == 0)
                animator.SetBool("IsMovingY", false);
            else
                animator.SetBool("IsMovingY", true);
        }

        if (player == null)
        {
            if (GameObject.FindGameObjectWithTag("Knight") != null)
            {
                player = GameObject.FindGameObjectWithTag("Knight");
            }
            else if (GameObject.FindGameObjectWithTag("Rogue") != null)
            {
                player = GameObject.FindGameObjectWithTag("Rogue");
            }
            else if (GameObject.FindGameObjectWithTag("Barbarian") != null)
            {
                player = GameObject.FindGameObjectWithTag("Barbarian");
            }
        }

        if (playerInRange)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
            if (sound != null)
            {
                sound.enabled = true;
            }
            if (AOEscript != null)
            {
                AOEscript.enabled = true;
            }
        }
        else
        {
            if (sound != null)
            {
                sound.enabled = false;
            }
            if (AOEscript != null)
            {
                AOEscript.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue" || collision.gameObject.tag == "Barbarian")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue" || collision.gameObject.tag == "Barbarian")
        {
            playerInRange = false;
        }
    }
}
