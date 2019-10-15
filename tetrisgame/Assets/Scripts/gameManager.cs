using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static int altura = 20;
    public static int largura = 10;

    public bool dentroGrade(Vector2 posicao)
    {
        return ((int)posicao.x > 0 && (int)posicao.x <= largura && (int)posicao.y > 0);
    }

    public Vector2 arrendonda(Vector2 nA)
    {
        return new Vector2(Mathf.Round(nA.x), Mathf.Round(nA.y));
    }
}
