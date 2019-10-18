using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static int altura = 20;
    public static int largura = 10;

    public int score = 0;
    public Text textScore;

    public static Transform[,] grade = new Transform[largura, altura];

    void Update()
    {
        textScore.text = score.ToString();   
    }
    public bool dentroGrade(Vector2 posicao)
    {
        return ((int)posicao.x >= 0 && (int)posicao.x < largura && (int)posicao.y >= 0);
    }

    public Vector2 arrendonda(Vector2 nA)
    {
        return new Vector2(Mathf.Round(nA.x), Mathf.Round(nA.y));
    }

    public void atualizaGrade(tetroMov pecaTetris)
    {
        for(int y = 0; y < altura; y++)
        {
            for(int x = 0; x < largura; x++)
            {
                if(grade[x, y] != null)
                {
                    if (grade[x, y].parent == pecaTetris.transform)
                    {
                        grade[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform peca in pecaTetris.transform)
        {
            Vector2 posicao = arrendonda(peca.position);
            if(posicao.y < altura)
            {
                grade[(int)posicao.x, (int)posicao.y] = peca;
            }
        }
    }
    public Transform posicaoTransGrade(Vector2 pos)
    {
        if(pos.y > altura - 1)
        {
            return null;
        }
        else
        {
            return grade[(int)pos.x, (int)pos.y];
        }
    }
    public bool linhaCheia(int y)
    {
        for(int x = 0; x < largura; x++)
        {
            if(grade[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }
    public void delQuad(int y)
    {
        for(int x = 0; x < largura; x++)
        {
            Destroy(grade[x, y].gameObject);

            grade[x, y] = null;
        }
    }
    public void moveLinhaBaixo(int y)
    {
        for(int x = 0; x < largura; x++)
        {
            if (grade[x, y] != null)
            {
                grade[x, y - 1] = grade[x, y];
                grade[x, y] = null;

                grade[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    public void moveTudoBaixo(int y)
    {
        for(int i = y; i < altura; i++)
        {
            moveLinhaBaixo(i);
        }
    }
    public void apaga()
    {
        for(int y = 0; y < altura; y++)
        {
            if (linhaCheia(y))
            {
                delQuad(y);
                moveTudoBaixo(y + 1);
                y--;
                score += 100;
            }
        }
    }
}
