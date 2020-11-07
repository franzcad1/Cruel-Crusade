using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" variables

    [SerializeField] private float speed = 10.0f;


    //Private Variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool hasEntered=false;
    private float initPos = 0.0f;
    private float finPos = 0.0f;
    private bool coolDown=true;
    private int counterCoolDown = 100;



    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    //Physics
    private void FixedUpdate()
    {
       float horiz = Input.GetAxis("Horizontal");
       float verti = Input.GetAxis("Vertical");
        
        if (counterCoolDown > 100 && coolDown==false)
        {
            coolDown = true;

        }
        else if (counterCoolDown > 130)
        {
            counterCoolDown = 0;
            coolDown = false;
        }
        else
        {
            counterCoolDown++;
        }


        if (gameObject.CompareTag("Knight") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player
            //stop movement
            rBody.velocity = new Vector2(horiz * 0, verti * 0);
        }
        else if(gameObject.CompareTag("Rogue") && Input.GetAxis("Jump") > 0 /*&& coolDown*/)
        {
            if(coolDown==true && counterCoolDown < 130) //logic to cool down the use of the roll
            {
                //do not destroy player
                //move quickly towards current direction
                rBody.velocity = new Vector2(horiz * (speed * 2), verti * (speed * 2));
                //haciendo la logica de coolDown con conatdor cada que pase el codio por fixedUpdate
            }
            else
            {
                rBody.velocity = new Vector2(horiz * speed, verti * speed);
                coolDown = false;
            }
           
        }
        else
        rBody.velocity = new Vector2(horiz * speed, verti * speed);

        //cominucate with animator
        anim.SetFloat("xVelocity",(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
    }
}
