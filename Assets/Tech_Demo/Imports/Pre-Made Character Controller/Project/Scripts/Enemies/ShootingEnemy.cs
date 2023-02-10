using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{

    public GameObject model;
    public float timeToRotate = 2f;

    private int targetAngle;
    private float rotationTimer;

    // Start is called before the first frame update
    void Start()
    {
        rotationTimer = timeToRotate;
    }

    // Update is called once per frame
    void Update()
    {
        rotationTimer -= Time.deltaTime;
        if (rotationTimer <= 0)
        {
            rotationTimer = timeToRotate;

            targetAngle += 90;
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, targetAngle, 0), Time.deltaTime);

    }
}
