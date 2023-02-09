using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController01 : MonoBehaviour
{

    public GameObject cubePrefab;
    public int cubeAmount = 10;
    public float randomArea = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //for (int num = 0; num < cubeAmount; num++)
        //{
            //GameObject cubeObject = Instantiate (cubePrefab);
            //cubeObject.transform.position = new Vector3(Random.Range(-randomArea, randomArea), Random.Range(-randomArea, randomArea), 0);
        //}
        int num = 0;
        while (num < cubeAmount)
        {
            GameObject cubeObject = Instantiate(cubePrefab);
            cubeObject.transform.position = new Vector3(Random.Range(-randomArea, randomArea), Random.Range(-randomArea, randomArea), 0);
            
            num++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
