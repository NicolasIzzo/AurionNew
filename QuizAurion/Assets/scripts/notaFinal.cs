using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notaFinal : MonoBehaviour
{
    private int idTema;
    public Text txtNota;
    public Text txtInfoTema;
    public GameObject estrela1, estrela2, estrela3;
    private int notaF, acertos;

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinalTemp"+idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você acertou " + acertos.ToString() + " de 15 perguntas";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
