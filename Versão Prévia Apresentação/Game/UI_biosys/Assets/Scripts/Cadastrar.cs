using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using Npgsql;
using System;

public class Cadastrar : MonoBehaviour
{
    public InputField nome;
    public InputField sobrenome;
    public InputField email;
    public InputField senha;
    public Text msg_erro;
    ///////////////////////////////
    public InputField nickname;
    public int id_img;
    public string nick;
    public string sql_jog;
    public Image imgIcon1;
    public Image imgIcon2;
    public Image imgIcon3;
    public Image imgIcon4;
    public Image imgIcon5;
    public Image imgIcon6;
    public Image imgIcon7;
    public Image imgIcon8;
    public Image imgIcon9;
    public Image imgIcon10;

    ///////////////////////////////
    public GameObject CADASTRO_USER;
    public GameObject CADASTRO_JOG;

    public string sql;
    public string sql1;
    public string nume;
    public string sobrename;
    public string emeil;
    public string passw;
    public string sql_email;
    public int icn;
    public string aux;
    /////////////////////////////////////
    /////////////////////////////////////
    
        


    public void debug()
    {
        Confirm_password conf = new Confirm_password();
        nume = nome.text;
        sobrename = sobrenome.text;
        emeil = email.text;
        passw = senha.text;
        sql = "INSERT INTO cadastro(id,nome,sobrenome, email, senha)" +
            " VALUES(default,'"+nume+"','"+sobrename+"'," +
            "'" + emeil+"'," +
            "'"+ passw + "');";
        sql_email = "SELECT email FROM cadastro WHERE email = '"+emeil+"';";
        Debug.Log(sql);
        Debug.Log(sql_email);
        try
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            if (Conexao.Email(sql_email) == true)
            {
                Conexao.executar(sql); 
                Debug.Log("Entrou em EMAIL");
                sql1 = "SELECT id FROM cadastro WHERE email = '" + emeil + "' AND senha = '" + passw + "';";
                mudatela(CADASTRO_USER, CADASTRO_JOG);
                aux = Conexao.Fk(sql1);//aux = aux_id
                Debug.Log("ESTOU AQUI");
                Debug.Log(aux);
                //CADASTRO_USER.SetActive(false);
                //CADASTRO_JOG.SetActive(true);
            }
            /*else
                conf.conf_email();//alteração*/
        }
        catch (NpgsqlException ex)
        {
            Debug.Log(ex.Message);
        }
        Confirm_password.conf_email();


        /*if (Conexao.Email(sql_email,true) == true)
        {
            Conexao.executar(sql);
            Debug.Log("vc ta aq?");
            cadjog.SetActive(true);
            caduser.SetActive(false);

            Conexao.desconectar();

        }
        else
        {
            msg_erro.gameObject.SetActive(true);
            msg_erro.text = "Email já existente";
            Conexao.desconectar();
        }*/

    }
    public void mudatela(GameObject g1, GameObject g2)
    {
        //g1 false e g2 true
        g1.gameObject.SetActive(false);
        g2.gameObject.SetActive(true);
    }
    ///////////////////////////////////////////////////////////////////////////
    public void Icon1()
    {
        icn = 1;
    }
    public void Icon2()
    {
        icn = 2;
    }
    public void Icon3()
    {
        icn = 3;
    }
    public void Icon4()
    {
        icn = 4;
    }
    public void Icon5()
    {
        icn = 5;
    }
    public void Icon6()
    {
        icn = 6;
    }
    public void Icon7()
    {
        icn = 7;
    }
    public void Icon8()
    {
        icn = 8;
    }
    public void Icon9()
    {
        icn = 9;
    }
    public void Icon10()
    {
        icn = 10;
    }
    public void Cadastra_jog()
    {
        int aux_int;
        aux_int = Convert.ToInt32(aux);
        //Conexao.conectar();
        try
        {
            nick = nickname.ToString();
            Debug.Log(nickname.text);
            sql_jog = "INSERT INTO jogador(username, id_user, vitorias, derrotas, conquistas,imagem) VALUES('"+ nick + "','"+aux_int+"',0,0,0," + icn + ");";//os 3 zeros são temporarios para vitoria derrota e conquista
            Conexao.executar(sql_jog);
            //Conexao.desconectar();
        }
        catch(NullReferenceException ex)
        {
            Debug.Log(ex.Message);
        }
    }
    
}
