using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shoot : MonoBehaviour
{
    public float bulletSpeed = 40.0f;
    public Rigidbody bulletRb;
    public int bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        bulletDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        ConstrainBullet();
    }

    private void FireBullet()
    {
        bulletRb.AddForce(transform.forward * bulletSpeed);
    }

    private void ConstrainBullet()
    {
        float westRange = -21f;
        float eastRange = 31f;
        float northRange = 29f;
        float southRange = -23f;
        if (transform.position.x < westRange || transform.position.x > eastRange || transform.position.z > northRange || transform.position.z < southRange)
        {
            Destroy(gameObject);
        } 
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
