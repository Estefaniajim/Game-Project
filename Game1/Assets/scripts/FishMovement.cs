using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
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
    transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(Time.time * speed),startPosition.z);
    }
}
