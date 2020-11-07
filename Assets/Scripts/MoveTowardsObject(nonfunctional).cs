using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public MonoBehaviour otherMovementScript;

    void Start()
    {

    }

    void Update()
    {
            
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {

        }
        else
        {
            otherMovementScript.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        otherMovementScript.enabled = true;
    }
}
