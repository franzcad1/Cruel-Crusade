using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectileP;
    [SerializeField] private GameObject player;
    [SerializeField] private bool playerInRange = false;

    public float speed = 20f;
    public float reloadtime = 5f;

    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", reloadtime, reloadtime);

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
            firePoint.transform.LookAt(player.transform.position);
        }
    }

    void Fire()
    {
        GameObject projectile = Instantiate(projectileP, firePoint.position, firePoint.rotation);
        Rigidbody2D p = projectile.GetComponent<Rigidbody2D>();
        p.AddForce(firePoint.right * speed, ForceMode2D.Impulse);

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
