using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongY : MonoBehaviour
{
    [SerializeField] private bool dirUp = true;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float distance = 4.0f;
    private float initialy;




    //Private Variables
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        initialy = rBody.position.y;
    }

    //Physics
    private void FixedUpdate()
    {
        if (dirUp)
            rBody.velocity = new Vector2(0, speed * 10f);
        else
            rBody.velocity = new Vector2(0, -speed * 10f);

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
