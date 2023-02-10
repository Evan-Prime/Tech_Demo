using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = gameObject.transform.position;
    }

    public void OnTriggerEnter (Collider other)
    {
        Vector3 deltaPosition = targetPosition - gameObject.transform.position;

        if (other.tag == "killBox")
        {
            transform.position = targetPosition;
        }

        if (other.tag == "checkPoint")
        {
            targetPosition = gameObject.transform.position;
        }
        

    }
}
