using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlayerController : Controller
{
    public CharacterController controller;
    public GameObject projectilePrefab;

    public float speed = 10.0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        ConstrainMovement();
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    // ABSTRACTION
    public void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    // ABSTRACTION
    public void ShootProjectile()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }


}
