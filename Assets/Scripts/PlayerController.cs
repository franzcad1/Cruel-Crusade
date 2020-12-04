using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" variables

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private GameObject boots;
    [SerializeField] private GameObject cloak;


    //Private Variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool hasEnteredBerserk=false;
    private bool hasEnteredRoll = false;
    private float initPos = 0.0f;
    private float finPos = 0.0f;
    private bool coolDownBerserk=false;
    private bool coolDownRoll = false;
    private bool roll = false;
    private bool shield = false;
    private bool berserk = false;
    private int counterCoolDown = 1000;
    private int counterCoolDownRoll = 100;
    private int counterTillCoolDownBeserk = 0;
    private int counterTillCoolDownRoll = 0;

    //Cloak
    private Renderer sprite;
    private Color colorOrig;
    private Color colorTrans;



    // Start is called before the first frame update
    void Start()
    {
        boots = GameObject.FindGameObjectWithTag("BootsUI");
        if (boots != null)
        {
            boots.gameObject.SetActive(false);
        }
        cloak = GameObject.Find("Cloak");
        if (cloak != null)
        {
            cloak.gameObject.SetActive(false);
        }
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        sprite = GetComponent<Renderer>();
        colorOrig = sprite.material.color;
        colorTrans = new Color(colorOrig.r, colorOrig.g, colorOrig.b, 0.5f);

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
        ///////////////////////////////////////////////cool down rutine
        if (counterCoolDown >= 1000 && coolDownBerserk == false) //COOLDOWN BERSERK
        {
            coolDownBerserk = true;
            counterCoolDown = 0;
            counterTillCoolDownBeserk = 0;
            

        }
        //////////////////////////////////////////////

        if (counterCoolDownRoll >= 200 && coolDownRoll == false) //COOLDOWN ROLL
        {
            coolDownRoll = true;
            counterCoolDownRoll = 0;
            
            counterTillCoolDownRoll = 0;

        }




        ///////////////////////////////////////////////
        if (hasEnteredBerserk == true)
        {
            counterTillCoolDownBeserk++;
            
            counterCoolDown = 0;
            
        }


        if (hasEnteredRoll == true)
        {
           
            counterTillCoolDownRoll++;
            ;
            counterCoolDownRoll = 0;
        }
        //////////////////////////////////////////////
        ///

        if (counterTillCoolDownBeserk>=300)
        {
            counterCoolDown++;

            coolDownBerserk = false;
            hasEnteredBerserk = false;
            
            berserk = false;
        }
        else
            coolDownBerserk = true;


        //////////////////////////////////////////

        if ( counterTillCoolDownRoll >= 50)
        {
            
            counterCoolDownRoll++;
            coolDownRoll = false;
            hasEnteredRoll = false;
            roll = false;
            
        }
        else
            coolDownRoll = true;
        ///////////////////////////////////////////

        if (gameObject.CompareTag("Knight") && Input.GetAxis("Jump") > 0)
        {
            //do not destroy player
            //stop movement
            rBody.velocity = new Vector2(horiz * 0, verti * 0);
            rBody.constraints = RigidbodyConstraints2D.FreezeAll; //so the enemy don´t drag player around
            shield = true;// activates shield animation
        }

        else if(gameObject.CompareTag("Barbarian") && Input.GetAxis("Jump") > 0)
        {
            //******Probitional condition just to make sure code enters this else if statement*****
            

            if (coolDownBerserk == true) //logic to cool down the use of the roll and Berserk
            {

                //move quickly towards current direction
                hasEnteredBerserk = true; //begins duration of attack berserk
                
                berserk = true; //activates animation
            }
            else
            {
                
                //coolDown = false;
                berserk = false;

            }


            
        }
        else if(gameObject.CompareTag("Rogue") && Input.GetAxis("Jump") > 0 /*&& coolDown*/)
        {
            if(coolDownRoll == true /*&& counterCoolDown < 130*/) //logic to cool down the use of the roll
            {
                //do not destroy player
                //move quickly towards current direction
                hasEnteredRoll = true; //begins duration of roll
                rBody.velocity = new Vector2(horiz * (speed * 2), verti * (speed * 2));
                roll = true; // activates Roll Animation
            }
            else
            {
                rBody.velocity = new Vector2(horiz * speed, verti * speed);
                //coolDown = false;
                roll = false;

            }
           
        }
        else
        {
            rBody.velocity = new Vector2(horiz * speed, verti * speed);
            shield = false;
            rBody.constraints = RigidbodyConstraints2D.None; // unfreeze position and start moving after shield
            rBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }



        //cominucate with animator
        anim.logWarnings = false;
        anim.SetFloat("xVelocity",(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("Attack", Input.GetMouseButtonDown(0));
        anim.SetBool("Roll", roll);
        anim.SetBool("Shield", shield);
        anim.SetBool("Berserk", berserk);

    }

    public void equipBoots()
    {
        boots.SetActive(true);
        this.speed += 1.5f;
    }

    public void equipCloak()
    {
        //make player untargetable by enemies
        cloak.SetActive(true);
        sprite.material.color = colorTrans;
    }
}
