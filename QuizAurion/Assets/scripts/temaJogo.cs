using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class temaJogo : MonoBehaviour
{
    public Button btnPlay;
    
    public Text txt1, txt2, txt3, txt4, txt5, txt6,
        txt7, txt8, txt9, txt10, txt11;

    public string[] nomeTema;

    private int numeroQuestoes;

    private int idTema;
    // Start is called before the first frame update
    void Start()
    {
        idTema = 0;
        txt1.text = nomeTema[1];
        txt2.text = nomeTema[2];
        txt3.text = nomeTema[3];
        txt4.text = nomeTema[4];
        txt5.text = nomeTema[5];
        txt6.text = nomeTema[6];
        txt7.text = nomeTema[7];
        txt8.text = nomeTema[8];
        txt9.text = nomeTema[9];
        txt10.text = nomeTema[10];
        txt11.text = nomeTema[11];

        btnPlay.interactable = false;
    }

    public void selecioneTema(int i)
    {
        idTema = i;
        btnPlay.interactable = true;
    }

    public void jogar()
    {
        Application.LoadLevel("T" + idTema.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
