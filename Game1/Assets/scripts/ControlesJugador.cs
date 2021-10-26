using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesJugador : MonoBehaviour
{
    //Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    public bool isinground;

    

    

    //FSM
    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;
    
    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private float hurtForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        scoreText.text = score.ToString();
        isinground = false;
    }

    private void Update()
    {
        if(state != State.hurt)
        {   
            
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation on enumerator state
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coins")
        {
            if(score <0){
                score = 0;
            }
            else{
            Destroy(collision.gameObject);
            score += 1;
            scoreText.text = score.ToString();
            }
            
        }

         
        
    }



    private void OnTriggerExit2D(Collider2D collision){
         if(collision.gameObject.tag == "ground"){
            isinground = false;
            Debug.Log(" no Tocando suelo");
        }

    }



    private void OnTriggerStay2D(Collider2D collision){
         if(collision.gameObject.tag == "ground"){
            isinground = true;
            Debug.Log("Tocando suelo");
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            enemy dog = other.gameObject.GetComponent<enemy>();

            if(state == State.falling)
            {
                dog.JumpOn();
                Jump();

            }
            else
            {
                state = State.hurt;
                if(other.gameObject.transform.position.x > transform.position.x)
                {
                    //enemy is on the right
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                    score -= 1;
                    scoreText.text = score.ToString();

                }
                else
                {
                    //enemy is to the left
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                    score -= 1;
                    scoreText.text = score.ToString();
                }
            }
    
        }
    }



  private void Movement()
    {
        
        float hDirection = Input.GetAxis("Horizontal");

        //moving left
        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            transform.localScale = new Vector3(-0.0771515742f,0.0717689022f,0.0717689022f);
        }

        //moving right
        else if(hDirection > 0)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
            transform.localScale = new Vector3(0.0771515742f,0.0717689022f,0.0717689022f);
        }
        //jumping
        
    if(Input.GetButtonDown("Jump") && isinground)
        {       
            
            Jump();
            isinground = false;
        }
    }
    private void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
        
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
