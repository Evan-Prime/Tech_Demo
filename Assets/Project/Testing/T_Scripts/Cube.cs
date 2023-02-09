using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public float sizeModifier = 2.5f;
    public string newName = "DaxCube";
    public bool isRotated = false;

    void Start()
    {
        transform.name = ImproveName(newName);
        
        if (isRotated)
        {
            transform.localEulerAngles = Vector3.one * 45;
        }
    }

    void Update()
    {
        transform.localScale = Vector3.one * sizeModifier;
        

    }

    string ImproveName (string originalString)
    {
        return "-{" + originalString + "}-";
    }

}
