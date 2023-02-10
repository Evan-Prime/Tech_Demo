using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [Header("Visuals")]
    public GameObject model;
    public TextMeshProUGUI arrowText;
    public TextMeshProUGUI bombText;
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

        SetArrowText();
        SetBombText();
        playerRigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {

        // Raycast to identify if the player can jump.
        if (Physics.Raycast(transform.position, Vector3.down, 1.02f))
        {
            canJump = true;
        }

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
                SetArrowText();
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
        SetBombText();
    }

    void SetArrowText()
    {
        arrowText.text = "Arrows: " + arrowAmount.ToString();
    }

    void SetBombText()
    {
        bombText.text = "Bombs: " + bombAmount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            other.gameObject.SetActive(false);
            arrowAmount = arrowAmount + 1;
            SetArrowText();
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            other.gameObject.SetActive(false);
            bombAmount = bombAmount + 1;
            SetBombText();
        }
    }
}
