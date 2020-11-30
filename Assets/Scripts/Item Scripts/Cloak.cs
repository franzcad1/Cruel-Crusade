using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Barbarian"))
            player = GameObject.FindGameObjectWithTag("Barbarian");
        else if (GameObject.FindGameObjectWithTag("Knight"))
            player = GameObject.FindGameObjectWithTag("Knight");
        else if (GameObject.FindGameObjectWithTag("Rogue"))
            player = GameObject.FindGameObjectWithTag("Rogue");

        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knight") || collision.gameObject.CompareTag("Barbarian") || collision.gameObject.CompareTag("Rogue"))
        {
            //add making player untargetable and cooldown

            playerController.equipCloak();
            Destroy(this.gameObject);
        }
    }
}
