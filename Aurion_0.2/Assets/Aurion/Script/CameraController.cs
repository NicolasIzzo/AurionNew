using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Camera userCam, gameCam;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        userCam.enabled = true;
        gameCam.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.activeSelf == true)
        {
            userCam.enabled = false;
            gameCam.enabled = true;
        }
        else
        {
            userCam.enabled = true;
            gameCam.enabled = false;
        }


    }
}
