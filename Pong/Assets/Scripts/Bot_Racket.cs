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
        rigido = GetComponent<Rigidbody2D>();
        vetorBot = new Vector2();
        bola = new Ball();
    }

    void Update()
    {
        /*speedBot = bola.dir.y;
        if(bola.dir.y > 0)
        {
            vetorBot.y += speedBot;
            //rigido = transform.position.y(speedBot);
            transform.Translate(Vector2.up * speedBot * Time.deltaTime);// * Time.deltaTime
        }
        else
        {
            vetorBot.y -= speedBot;
            transform.Translate(Vector2.down * speedBot * Time.deltaTime);
        }*/
        bot = GameObject.FindGameObjectWithTag("Bot").transform;
       // botMov= bot.GetComponent<rigido>();


        while (true)
        {
            bot.transform.position = new Vector2(0, bola.dir.y);
        }

    }
}
