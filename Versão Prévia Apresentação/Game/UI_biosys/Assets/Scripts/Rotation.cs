using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rotation : MonoBehaviour
{
    //void update = a cada frame há a repetição do código inserido dentro dele
    void Update()
    {
        //modifica a classe transform do objeto e rotaciona a cada segundo (Time.deltaTime = 1 segundo) 70° no eixo Y
        transform.Rotate(0, 70 * Time.deltaTime, 0); //(x,y,z)
    }
}
