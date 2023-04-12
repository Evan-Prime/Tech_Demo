using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject target;
    public AudioClip portClip;

    private AudioManager audioManager;
    private bool leave;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        leave = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            if (leave == true)
            {
                audioManager.PlayAudio(portClip);
                leave = false;
                other.transform.position = target.transform.position;
            }
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        leave = true;
    }
}
