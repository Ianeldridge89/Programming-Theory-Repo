using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    public int enemyHP = 20;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = 20;
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
