using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        ConstrainMovement();
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }

    private void ConstrainMovement()
    {
        if (transform.position.x < -19.5)
        {
            transform.position = new Vector3(-19.5f, transform.position.y, transform.position.z);
        }
    }
}
