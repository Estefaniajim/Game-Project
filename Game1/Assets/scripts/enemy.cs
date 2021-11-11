using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    private Animator anim;
    private Collider2D coll;
    private float initial;
    public int range;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        initial = transform.position.x;
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

        float deltax = transform.position.x - initial;

        if (deltax > range)
        {
            MoveRight = false;
        }
        if (deltax < -range)
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
    public void SetDead()
    {
        anim.SetTrigger("Dead");
    }
}