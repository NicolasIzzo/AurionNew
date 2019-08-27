using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Npgsql;
using System;
public class Login : MonoBehaviour
{

    //Cadastrar cad = caduser.AddComponent<Cadastrar>();
    public InputField inpEmail;
    public InputField inpPasswd;
    public string email;
    public string sql;
    public string senha;
    public GameObject login;
    public GameObject inicial;
    public Text msgerro;
    
    public void Logon()
    {
        msgerro.gameObject.SetActive(false);
        NpgsqlCommand comma = new NpgsqlCommand();
        try
        {
           
            email = inpEmail.text;
            senha = inpPasswd.text;
            Debug.Log(email);
            Debug.Log(senha);
            sql = "SELECT * FROM cadastro WHERE email = '" + email + "' AND senha = '" + senha + "';";
            if (Conexao.Email(sql) == false)
            {
                Debug.Log("Logou");
                login.SetActive(false);
                inicial.SetActive(true);
            }
            else
                throw new Exception();
        }       
        catch(Exception ex)
        {
            Debug.Log("Deu merda"+ex.Message);
            msgerro.gameObject.SetActive(true);

        }
    }
}
