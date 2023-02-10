using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TExplosion : MonoBehaviour
{

    public GameObject[] particlePrefabs;
    public int amountOfParticles = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfParticles; i++)
        {
            GameObject particlePrefab = Instantiate(particlePrefabs[Random.Range(0, particlePrefabs.Length)]);
            particlePrefab.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
