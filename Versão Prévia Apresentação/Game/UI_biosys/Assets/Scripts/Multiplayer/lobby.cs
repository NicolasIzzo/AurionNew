using System.Collections;
using UnityEngine;

public class lobby : Photon.MonoBehaviour
{
    private string _nomeJogador = "";
    private string auxiliar = "";


    void Start()
    {
        _nomeJogador = "jogador" + Random.Range(1, 999).ToString();
        auxiliar = "desconectado";
        pConnect();
    }

    void pConnect()
    {
        if (!PhotonNetwork.connected)
        {
            auxiliar = "n conectado";
            PhotonNetwork.playerName = _nomeJogador;
            PhotonNetwork.ConnectUsingSettings("v1");
            auxiliar = "conectado";
        }

        if (PhotonNetwork.connected)
        {
            auxiliar = "conectado2";
            Debug.Log(auxiliar);
        }
        
    }
}
