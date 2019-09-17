using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bot_Racket : MonoBehaviour
{
    private Vector2 vetorBot;
    private float speedBot = 0.0f;
    private Rigidbody2D rigido;

    private Ball bola;
    
    void Start()
    {
        rigido = GetComponent<Rigidbody2D>();
        vetorBot = new Vector2();
        bola = new Ball();
    }
    /*Vector2 screenPosition = Camera.main.WorldToScreenPoint(text.transform.position);
Vector2 guiPosition = new Vector2(screenPosition.x / Screen.width, screenPosition.y / Screen.height);
text.transform.position = GUIUtility.ScreenToGUIPoint(guiPosition);*/

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
        while (true)
        {
            rigido.transform.position = new Vector2(0, bola.dir.y);
        }

    }
}
