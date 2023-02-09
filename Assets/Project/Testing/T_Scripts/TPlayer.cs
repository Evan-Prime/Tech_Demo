using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayer : MonoBehaviour
{

    public float speed = 3.5f;
    public float rotatingSpeed = 40f;
    public float jumpingForce = 10f;
    public GameObject bulletPrefab;
    public Transform gun;

    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown (0))
        {
            GameObject bulletObject = Instantiate (bulletPrefab, gun);
            //bulletObject.transform.position = transform.position;
            //bulletObject.transform.rotation = transform.rotation;
            TBullet bullet = bulletObject.GetComponent<TBullet>();

            Vector3 shootingDirection = transform.forward;

            bullet.shootingDirection = shootingDirection.normalized;

        }


    }

    private void Movement()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.RotateAround(transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
            Debug.Log("Turn Right");
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotatingSpeed * Time.deltaTime);
            Debug.Log("Turn Left");
        }

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            Debug.Log("Move Up");
        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
            Debug.Log("Move Down");
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Floor")
        {
            Debug.Log("Hit the floor");
            canJump = true;
        }
    }
}
