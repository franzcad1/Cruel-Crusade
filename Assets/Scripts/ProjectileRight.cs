using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
