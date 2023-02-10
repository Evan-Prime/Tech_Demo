using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Visuals")]
    public GameObject model;
    public float rotatingSpeed = 2f;

    [Header("Movement")]
    public float speed;
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
        //targetModelRotation = Quaternion.Euler (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        // Raycast to identify if the player can jump.
        if (Physics.Raycast(transform.position, Vector3.down, 1.02f))
        {
            canJump = true;
        }
        
    }

    private void FixedUpdate()
    {
        ProcessInput();
        
    }

    void ProcessInput()
    {
        // Move in the XZ plane.
        // 

        if (Input.GetKey("w"))
        {
            
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);

        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.Self);

        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.Self);

        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.Self);

        }

        // Check for jumps.
        if (canJump == true && Input.GetKey("space"))
        {
            canJump = false;
            playerRigidbody.AddRelativeForce(new Vector3(0, jumpingVelocity, 0), ForceMode.Force);
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
