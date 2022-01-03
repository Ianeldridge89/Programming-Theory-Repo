using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Parent Class of both enemy and playercontroller
    public static float westRange = -19.5f;
    public static float eastRange = 29.0f;
    public static float northRange = 27.0f;
    public static float southRange = -21.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // POLYMORPHISM
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            MainManager.GameOver();
            
        }
    }


    // ABSTRACTION
    public void ConstrainMovement()
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
