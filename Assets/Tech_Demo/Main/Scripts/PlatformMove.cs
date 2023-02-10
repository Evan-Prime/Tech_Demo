using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform rightTarget;
    public Transform leftTarget;
    public Transform target;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, target.position) > 0.01f)
        {
            gameObject.transform.Translate((target.position - gameObject.transform.position).normalized * speed * Time.deltaTime);
        }
        else 
        {
            if(target == rightTarget)
            {
                target = leftTarget;
            }
            else
            {
                target = rightTarget;
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.collider.transform.parent = gameObject.transform;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.collider.transform.parent = null;
        }
    }
}
