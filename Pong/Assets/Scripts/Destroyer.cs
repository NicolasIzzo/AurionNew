using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject bot;
    private float tempo, pontuacao = 0f;
    public Bot_Racket buti;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        bot = GameObject.FindGameObjectWithTag("Bot");
        Destroy(bot);
        GameObject collider = collision.collider.gameObject;
        GameObject.Destroy(collider);
        Debug.Log("Game Over");
        Debug.Log(tempo);        
        Application.Quit();
    }
 
}
