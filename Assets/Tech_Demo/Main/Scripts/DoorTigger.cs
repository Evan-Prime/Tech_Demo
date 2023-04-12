using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTigger : MonoBehaviour
{
    
    public GameObject rightDoor;
    public GameObject leftDoor;
    public Transform rightTarget;
    public Transform leftTarget;
    public float speed;
    public AudioClip doorClip;

    private AudioManager audioManager;
    bool isOpening;

    Vector3 rightStart;
    Vector3 leftStart;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        rightStart = rightDoor.transform.position;
        leftStart = leftDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening == true)
        {
            if (Vector3.Distance(rightDoor.transform.position, rightTarget.position) > 0.01f)
            {
                rightDoor.transform.Translate((rightTarget.position - rightDoor.transform.position).normalized * speed * Time.deltaTime);
            }
            if (Vector3.Distance(leftDoor.transform.position, leftTarget.position) > 0.01f)
            {
                leftDoor.transform.Translate((leftTarget.position - leftDoor.transform.position).normalized * speed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(rightDoor.transform.position, rightStart) > 0.01f)
            {
                rightDoor.transform.Translate((rightStart - rightDoor.transform.position).normalized * speed * Time.deltaTime);
            }
            if (Vector3.Distance(leftDoor.transform.position, leftStart) > 0.01f)
            {
                leftDoor.transform.Translate((leftStart - leftDoor.transform.position).normalized * speed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            audioManager.PlayAudio(doorClip);
            isOpening = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            isOpening = false;
        }
    }
}
