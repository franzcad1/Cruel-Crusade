using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private GameObject projectileP;
    [SerializeField] private GameObject player;
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sound;

    public float speed = 5f;
    public float reloadtime = 2f;

    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
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

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed);
            //need to face player when firing
            //firePoint.LookAt(player.transform);
            //firePoint.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, player.transform.position - firePoint.position, 100f, 0.0f));
            Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(Vector3.forward * (angle));
            if (animator != null)
            {
                animator.SetBool("IsFiring", true);
            }
            if (sound != null)
            {
                sound.enabled = true;
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("IsFiring", false);
            }
            if (sound != null)
            {
                sound.enabled = false;
            }
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectileP, firePoint.position, firePoint.rotation);
        Rigidbody2D p = projectile.GetComponent<Rigidbody2D>();
        Vector3 target = (player.transform.position - firePoint.position).normalized * speed;
        p.velocity = (new Vector3(target.x, target.y, 0.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue" || collision.gameObject.tag == "Barbarian")
        {
            playerInRange = true;

            InvokeRepeating("Fire", reloadtime, reloadtime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight" || collision.gameObject.tag == "Rogue" || collision.gameObject.tag == "Barbarian")
        {
            playerInRange = false;
            CancelInvoke("Fire");
        }
    }
}
