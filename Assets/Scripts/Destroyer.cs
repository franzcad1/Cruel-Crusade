﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    //public GameObject death;
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
        else if (other.gameObject.CompareTag("Timeline"))
        {
            //no enemy friendlyfire
        }
        else if (other.gameObject.CompareTag("Knight") || other.gameObject.CompareTag("Rogue") || other.gameObject.CompareTag("Barbarian"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(5);     
        }
    }
}
