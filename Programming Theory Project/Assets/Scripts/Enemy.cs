using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : Controller
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private static int enemyHP;
    public int enemyPointsValue;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyHP = 10;
        speed = 3.0f;
        enemyPointsValue = 2;
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

        if (other.gameObject.tag == "Bullet")
        {
            int damage = other.gameObject.GetComponent<Shoot>().bulletDamage;
            TakeDamage(damage);
            Destroy(other.gameObject);
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                MainManager.UpdateScore(enemyPointsValue);
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player killed! GAME OVER");
        }

    }

    public static void TakeDamage(int damage)
    {
        enemyHP = enemyHP - damage;
        Debug.Log("HIT. health remaining: " + enemyHP);
    }
}
