using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    private Animator anim;
    private Collider2D coll;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(0.0706262514f, 0.0706262514f);

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-0.0706262514f, 0.0706262514f);
        }
        if (transform.position.x > 11)
        {
            MoveRight = false;
        }
        if (transform.position.x < 3.7)
        {
            MoveRight = true;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {

            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
    public void Dead()
    {
        Destroy(this.gameObject);

    }
    public void JumpOn()
    {
        anim.SetTrigger("Dead");
    }
}