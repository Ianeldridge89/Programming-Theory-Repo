using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Parent Class of both enemy and playercontroller
    private float westRange = -19.5f;
    private float eastRange = 20.0f;
    private float northRange = 20.0f;
    private float southRange = -20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConstrainMovement()
    {
        if (transform.position.x < westRange)
        {
            transform.position = new Vector3(westRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > eastRange)
        {
            transform.position = new Vector3(eastRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > northRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, northRange);
        }
        if (transform.position.z < southRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, southRange);
        }
    }
}
