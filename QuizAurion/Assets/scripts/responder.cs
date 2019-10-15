using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class responder : MonoBehaviour
{
    public int idTema;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text respostaE;
    public Text infoResp;//estabelece genericamente os campos onde ficarão as respostas possiveis, o tema e a resposta correta

    public string[] perguntas;
    public string[] alternativaA;
    public string[] alternativaB;
    public string[] alternativaC;
    public string[] alternativaD;
    public string[] alternativaE;//estabelece a variavel que abrigara a pergunta  as respostas, que variam.

    public string[] corretas;

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;//

    // Start is called before the first frame update
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema"); //atribui a id tema o tema
        idPergunta = 0;//pergunta começa em 0 e vai até o numero de questões dentro do tema
        questoes = perguntas.Length;//numeroo de questões
        pergunta.text = perguntas[idPergunta];//pega a pergunta do id atribuido
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];
        respostaE.text = alternativaE[idPergunta];//cria a alternativa, de A até E 
        infoResp.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas";//mostra em qual opergunta está
        

    }

    public void resposta(string alternativa)
    {
        if(alternativa=="A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp a
        }

        if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp b
        }

        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp c
        }

        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp d
        }

        else if (alternativa == "E")
        {
            if (alternativaE[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
            // executa o comandopara resp e
        }
        proximaPergunta();
    }

   void proximaPergunta()
    {
        idPergunta += 1;//almenta o indice da pergunta

        if (idPergunta <= (questoes - 1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];
            respostaE.text = alternativaE[idPergunta];
            infoResp.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas ";
        }//atribui os novos campos se ainda houverem questões

        else
        {
            media = (acertos / questoes) * 10;
            notaFinal = Mathf.RoundToInt(media);// arredonda para o proximo inteiro
             
            if(notaFinal>PlayerPrefs.GetInt("notaFinal"+idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);

            Application.LoadLevel("notaFinal");
          // o que fazer se terminar as perguntas
        }


    }

}
