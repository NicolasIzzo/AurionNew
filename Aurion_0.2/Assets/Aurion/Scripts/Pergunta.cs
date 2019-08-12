using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Resposta
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }

    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; } }
}
public class Pergunta : ScriptableObject
{
    public enum TipoResposta { Unica, Varias }

    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }

    [SerializeField] Resposta[] _respostas = null;
    public Resposta[] Respostas { get { return _respostas; } }

    //Parâmetros

    [SerializeField] private bool _useTimer = false;
    public bool UseTimer { get { return _useTimer; } }

    [SerializeField] private int _timer;
    public int Timer { get { return _timer; } }

    [SerializeField] private TipoResposta _tipoResposta = TipoResposta.Unica;
    public TipoResposta GetTipoResposta { get { return _tipoResposta; } }

    [SerializeField] private int _addPontos = 10;
    public int AddPontos { get { return _addPontos; } }

    public List<int> GetRespostasCorretas()
    {
        List<int> RespostasCorretas = new List<int>();
        for(int i = 0; i < Respostas.Length; i++)
        {
            if(Respostas[i].IsCorrect)
            {
                RespostasCorretas.Add(i);
            }
        }
        return RespostasCorretas;
    }


}
