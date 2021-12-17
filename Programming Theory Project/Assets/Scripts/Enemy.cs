using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : Controller
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    public int enemyPointsValue;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        speed = 3.0f;
        enemyPointsValue = 1;
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

    // POLYMORPHISM
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            int damage = other.gameObject.GetComponent<Shoot>().bulletDamage;
            Destroy(other.gameObject);
            Destroy(gameObject);
            MainManager.UpdateScore(enemyPointsValue);
        }
    }
}
