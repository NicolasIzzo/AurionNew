using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Racket : MonoBehaviour
{
    private Vector2 vetorBot;
    private float speedBot = 0f;
    private Rigidbody2D rigido;
    private Transform bot,bolls;
    private Transform botMov;
    private Component RacketLeft_Bot;
    private float auxBotY, auxBallY;

    private Ball bola;


    void Start()
    {        
        bola = new Ball();
        bot = GameObject.FindGameObjectWithTag("Bot").transform;
        bolls = GameObject.FindGameObjectWithTag("Ball").transform;
        speedBot = bola.dir.y;
        vetorBot = new Vector2(-38,-13);
    }

    void Update()
    {
        mudaValor();
        
    }
    private void mudaValor()
    {
        auxBotY = bolls.transform.position.y;
        bot.transform.position = new Vector2(-38,auxBotY);
    }
}
