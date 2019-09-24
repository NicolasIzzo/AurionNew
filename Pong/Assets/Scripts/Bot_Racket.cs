using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Racket : MonoBehaviour
{
    private Vector2 vetorBot;
    private float speedBot = 0.0f;
    private Rigidbody2D rigido;
    private Transform bot;
    private Transform botMov;


    private Ball bola;


    void Start()
    {
        //rigido = GetComponent<Rigidbody2D>();
        //vetorBot = new Vector2();
        bola = new Ball();
        bot = GameObject.FindGameObjectWithTag("Bot").transform;
        speedBot = bola.dir.y;
        bot.transform.position = new Vector2(-38,-13);
    }

    void Update()
    {       
        mudaValor();
    }
    private void mudaValor()
    {        
        bot.transform.position = new Vector2(-38, speedBot);
    }
    //conectar ccom o scriptda bla e lançar a função mudaValor no Ball.cs, lá rodá-la, e no update da Ball, conseguir faze a bola mexer.
 


}
