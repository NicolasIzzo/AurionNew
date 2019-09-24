using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Racket : MonoBehaviour
{
    private Vector2 vetorBot;
    private float speedBot = -13f;
    private Rigidbody2D rigido;
    private Transform bot,bolls;
    private Transform botMov;
    private Component RacketLeft_Bot;


    private Ball bola;


    void Start()
    {
        
        //rigido = GetComponent<Rigidbody2D>();
        //vetorBot = new Vector2();
        bola = new Ball();
        bot = GameObject.FindGameObjectWithTag("Bot").transform;
        bolls = GameObject.FindGameObjectWithTag("Ball").transform;
        //rigido = bot.GetComponent<>();
        speedBot = bola.dir.y;
        vetorBot = new Vector2(-38,-13);
        mudaValor();
    }

    void Update()
    {
        // mudaValor();
       // Debug.Log("Filho da puta eu to aqui caralho");
        
    }
    private void mudaValor()
    {
        //if()
        float aux;
        if (bolls.transform.position.y < 0)
            bot.transform.Translate(Vector2.up * (Time.deltaTime + 0.05f));
        else if (bolls.transform.position.y > 0)
            bot.transform.Translate(Vector2.down * (Time.deltaTime + 0.05f));
        /*if (bolls.transform.position.y != 0)
        {
            
            //aux = bola.dir.y;
            //vetorBot = new Vector2(38, );
           
        }*/
        // else
        // {
        /* if (bola.dir.y == 0)
             bot.transform.Translate(Vector2.up * 0);*/


        /*aux = bola.dir.y;            
        vetorBot = new Vector2(0, -aux);            
        bot.transform.Translate(vetorBot * (Time.deltaTime + 0.05f));*/
        // }

    }
    //conectar ccom o scriptda bla e lançar a função mudaValor no Ball.cs, lá rodá-la, e no update da Ball, conseguir faze a bola mexer.

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        mudaValor();
    }



}
