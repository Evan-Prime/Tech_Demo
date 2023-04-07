using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject arrowPrefab;
    public AudioClip shootClip;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        audioManager.PlayAudio(shootClip);
        GameObject arrowObject = Instantiate(arrowPrefab);
        arrowObject.transform.position = transform.position + transform.forward;
        arrowObject.transform.forward = transform.forward;
        
    }
}
