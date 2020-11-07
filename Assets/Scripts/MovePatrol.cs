using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatrol : MonoBehaviour
{
    // "Public" variables
    private bool dirUp = true;
    private bool dirRight = true;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float distance = 4.0f;
    private float initialx;
    private float initialy;




    //Private Variables
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        initialx = rBody.position.x;
        initialy = rBody.position.y;
    }

    //Physics
    private void FixedUpdate()
    {
        if (dirRight)
            rBody.velocity = new Vector2(speed * 10f, 0);
        else
            rBody.velocity = new Vector2(-speed * 10f, 0);

        if (dirUp && rBody.position.x >= initialx + distance)
            rBody.velocity = new Vector2(0, speed * 10f);
        else if (dirUp == false && rBody.position.x <= initialx - distance)
            rBody.velocity = new Vector2(0, -speed * 10f);

        if (rBody.position.x >= initialx + distance)
        {
            dirRight = false;
        }

        if (rBody.position.x <= initialx - distance)
        {
            dirRight = true;
        }

        if (rBody.position.y >= initialy + distance)
        {
            dirUp = false;
        }

        if (rBody.position.y <= initialy - distance)
        {
            dirUp = true;
        }
    }
}
