using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_ice : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        GameObject.Destroy(collider);
        Debug.Log("BOLINHA FOI PRO BREJO");
        Debug.Log("Quit");
        Debug.Log("PONTUAÇÃO:" + Bloco.pontos);
        //Show_point.MostraPontos(Bloco.pontos);
        // Application.Quit();
        
    }
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.Destroy(collider.gameObject);
    }
}
