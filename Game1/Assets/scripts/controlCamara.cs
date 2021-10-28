using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamara : MonoBehaviour
{
    int speed = 5;
    Vector2 movement;
   public Rigidbody2D rb;
   ControlesJugador controlesJugador;

    public void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector3(0,0,0);
            
            //rb.MovePosition(-rb.position + movement*speed*Time.deltaTime);
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector3(0.0771515742f,0.0717689022f,0.0717689022f);
        }
        if(Input.GetKeyDown(KeyCode.Space) && controlesJugador.isinground)
        {
            rb.velocity = new Vector3(rb.velocity.x, 7f);
            controlesJugador.isinground = false;
        }
    }
}
