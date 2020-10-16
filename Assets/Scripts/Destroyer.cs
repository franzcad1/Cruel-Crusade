using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else
        {
            Destroy(other.gameObject);
        }
    }
}
