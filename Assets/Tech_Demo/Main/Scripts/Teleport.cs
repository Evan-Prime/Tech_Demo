using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject target;
    private bool leave;

    private void Start()
    {
        leave = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            if (leave == true)
            {
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
