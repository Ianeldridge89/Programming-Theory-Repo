using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : Controller
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        ConstrainMovement();
        FollowPlayer();
    }

    // ABSTRACTION
    private void FollowPlayer()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player killed! GAME OVER");

        }
    }
}
