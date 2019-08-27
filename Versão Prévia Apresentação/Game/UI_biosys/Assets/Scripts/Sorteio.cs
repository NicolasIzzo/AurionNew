using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorteio : MonoBehaviour
{
    public Sprite[] cards;
    //sorteio//
    int axe;
    int numeroSort;
    List<int> jaSort = new List<int>();

    List<int> numeros = new List<int>();

    List<int> j1 = new List<int>();
    List<int> j2 = new List<int>();
    List<int> j3 = new List<int>();
    List<int> j4 = new List<int>();

    //mostra cartas//

    public Sprite[] cartasNaMao;

    //-------------------------------------------------------//
    void Start()
    {
        for (int x = 0; x <= 36; x++)
        {
            numeros.Add(x);
        }
        Sorteia();
    }


    void Sorteia()
    {
        for (int x = 1; x <= 9; x++)
        {
            int indice = Random.Range(1, numeros.Count);
            numeroSort = numeros[indice];
            j1.Add(numeroSort);
            jaSort.Add(numeroSort);
            numeros.Remove(numeros[indice]);
        }
        for (int x = 1; x <= 9; x++)
        {
            int indice = Random.Range(1, numeros.Count);
            numeroSort = numeros[indice];
            j2.Add(numeroSort);
            jaSort.Add(numeroSort);
            numeros.Remove(numeros[indice]);
        }
        for (int x = 1; x <= 9; x++)
        {
            int indice = Random.Range(1, numeros.Count);
            numeroSort = numeros[indice];
            j3.Add(numeroSort);
            jaSort.Add(numeroSort);
            numeros.Remove(numeros[indice]);
        }
        for (int x = 1; x <= 9; x++)
        {
            int indice = Random.Range(1, numeros.Count);
            numeroSort = numeros[indice];
            j4.Add(numeroSort);
            jaSort.Add(numeroSort);
            numeros.Remove(numeros[indice]);
        }
        MostrarCartas();
    }

    void MostrarCartas()
    {
        for (int y = 0; y < 9; y++)
        {
            int axe = j1[y];
            cartasNaMao[y] = cards[axe];
        }
    }

}
