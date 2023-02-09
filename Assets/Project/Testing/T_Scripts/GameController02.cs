using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController02 : MonoBehaviour
{

    public GameObject[] gameCameras;

    private int gameCameraIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       FocusOnCamera (gameCameraIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Q))
        {
            ChangeCamera (1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeCamera(-1);
        }
    }

    void FocusOnCamera (int index)
    {
        for (int i = 0; i < gameCameras.Length; i++)
        {
            gameCameras[i].SetActive (i == index);
        }
    }

    void ChangeCamera (int direction)
    {
        gameCameraIndex += direction;

        if (gameCameraIndex >= gameCameras.Length)
        {
            gameCameraIndex = 0;
        }

        if (gameCameraIndex < 0)
        {
            gameCameraIndex = gameCameras.Length - 1;
        }

        FocusOnCamera (gameCameraIndex);
    }
}
