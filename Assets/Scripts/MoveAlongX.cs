using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongX : MonoBehaviour
{
    // "Public" variables

    [SerializeField] private bool dirRight = true;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float distance = 4.0f;
    private float initialx;




    //Private Variables
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        initialx = rBody.position.x;
    }

    //Physics
    private void FixedUpdate()
    {
        if (dirRight)
            rBody.velocity = new Vector2(speed * 10f, 0);
        else
            rBody.velocity = new Vector2(-speed * 10f, 0);

        if (rBody.position.x >= initialx + distance)
        {
            dirRight = false;
        }

        if (rBody.position.x <= initialx - distance)
        {
            dirRight = true;
        }
    }
}
