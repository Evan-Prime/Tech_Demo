using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float timer = 3.0f;
    private float duration = 3.0f;

    public GameObject pickUp;

    // Update is called once per frame
    void Update()
    {
        if (pickUp.activeSelf == false)
        {
            timer -= Time.deltaTime;
            if (timer < 0.0f)
            {
                pickUp.SetActive(true);
                timer = duration;
            }
        }
    }
}
