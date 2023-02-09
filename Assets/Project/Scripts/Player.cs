using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Visuals")]
    public GameObject model;
    public float rotatingSpeed = 2f;

    [Header("Movement")]
    public float movingVelocity;
    public float jumpingVelocity;

    [Header("Equipment")]
    public Sword sword;
    public Bow bow;
    public int arrowAmount = 15;
    public GameObject bombPrefab;
    public int bombAmount = 5;
    public float throwingSpeed;

    private Rigidbody playerRigidbody;
    private bool canJump;
    private Quaternion targetModelRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        bow.gameObject.SetActive(false);

        playerRigidbody = GetComponent<Rigidbody> ();
        targetModelRotation = Quaternion.Euler (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        // Raycast to identify if the player can jump.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            canJump = true;
        }

        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotatingSpeed);
        
        ProcessInput();
    }

    void ProcessInput()
    {
        // Move in the XZ plane.
        playerRigidbody.velocity = new Vector3(
            0,
            playerRigidbody.velocity.y,
            0
        );

        if (Input.GetKey("d"))
        {
            playerRigidbody.velocity = new Vector3(
                movingVelocity,
                playerRigidbody.velocity.y,
                playerRigidbody.velocity.z
            );

            targetModelRotation = Quaternion.Euler (0, 90, 0);
        }
        if (Input.GetKey("a"))
        {
            playerRigidbody.velocity = new Vector3(
                -movingVelocity,
                playerRigidbody.velocity.y,
                playerRigidbody.velocity.z
            );

            targetModelRotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(
                playerRigidbody.velocity.x,
                playerRigidbody.velocity.y,
                movingVelocity
            );

            targetModelRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            playerRigidbody.velocity = new Vector3(
                playerRigidbody.velocity.x,
                playerRigidbody.velocity.y,
                -movingVelocity
            );

            targetModelRotation = Quaternion.Euler(0, 180, 0);
        }

        // Check for jumps.
        if (canJump && Input.GetKeyDown ("space"))
        {
            canJump = false;
            playerRigidbody.velocity = new Vector3 (
                playerRigidbody.velocity.x,
                jumpingVelocity,
                playerRigidbody.velocity.z
           );
        }

        // Check equipment interaction.
        if (Input.GetKeyDown("e"))
        {
            sword.gameObject.SetActive (true);
            bow.gameObject.SetActive (false);
            sword.Attack ();
        }

        if (Input.GetKeyDown("f"))
        {
            sword.gameObject.SetActive (false);
            bow.gameObject.SetActive (true);
            if (arrowAmount > 0)
            {
                bow.Attack ();
                arrowAmount--;
            }
        }

        if (Input.GetKeyDown("q"))
        {
            ThrowBomb ();
        }
    }

    private void ThrowBomb()
    {
        if (bombAmount <= 0)
        {
            return;
        }
        GameObject bombObject = Instantiate(bombPrefab);
        bombObject.transform.position = transform.position + model.transform.forward;

        Vector3 throwingDirection = (model.transform.forward + Vector3.up).normalized;

        bombObject.GetComponent<Rigidbody> ().AddForce (throwingDirection * throwingSpeed);

        bombAmount--;
    }
}
