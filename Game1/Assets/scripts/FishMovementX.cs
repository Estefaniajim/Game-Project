using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovementX : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 2.5f;
    Vector3 startPosition;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = new Vector3(startPosition.x + Mathf.Sin(Time.time * speed), startPosition.y ,startPosition.z);
    }
}
