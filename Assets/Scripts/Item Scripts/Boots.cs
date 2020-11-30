using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour

    
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
       

   
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Barbarian"))
            player = GameObject.FindGameObjectWithTag("Barbarian");
        else if (GameObject.FindGameObjectWithTag("Knight"))
            player = GameObject.FindGameObjectWithTag("Knight");
        else if (GameObject.FindGameObjectWithTag("Rogue"))
            player = GameObject.FindGameObjectWithTag("Rogue");

        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knight") || collision.gameObject.CompareTag("Barbarian") || collision.gameObject.CompareTag("Rogue"))
        {
            playerController.equipBoots();
            Destroy(this.gameObject);
        }
    }
}
