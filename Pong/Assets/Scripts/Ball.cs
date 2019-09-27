﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class Ball : MonoBehaviour
{
    public float speedBall;
    public Vector2 dir;
    private Bot_Racket bot;
    public int inter;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speedBall;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
 
        float y = hitFactor(transform.position, col.transform.position,
            col.collider.bounds.size.y);
        dir = new Vector2(-1, y).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speedBall;
        inter = Integer.parseInt32(GetComponent<Rigidbody2D>().velocity);
        //bot.dificuldade++;
        //Debug.Log("BateuBB");
    }
    private void Update()
    {
      //  GetComponent<Rigidbody2D>().velocity = dir * speedBall;
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {   
        return (ballPos.y - racketPos.y) / racketHeight;        
    }
}
