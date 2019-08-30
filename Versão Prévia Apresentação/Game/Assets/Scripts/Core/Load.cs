using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public Image logo;

    void Update()
    {
        logo.transform.Rotate(180 * Time.deltaTime, 180*Time.deltaTime, 180 * Time.deltaTime);
        //Sleep(1000);

    }
}
