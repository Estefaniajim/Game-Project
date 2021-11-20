using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakumberMovement : MonoBehaviour
{

    public int moved;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        moved = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            if(moved < 500)
            {
                transform.position += new Vector3(0, 0.01f, 0);
                moved++;
            }
            else
            {
                up = false;
            }
        }
        else
        {
            if (moved > 0)
            {
                transform.position -= new Vector3(0, 0.01f, 0);
                moved--;
            }
            else
            {
                up = true;
            }
        }
    }
}
